using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    [Header("Speed setup")]
    public SOPlayerSetup soPlayerSetup;
    private float _currentSpeed;
    //private bool _isRunning = false;
    public HealthBase healthBase;
    //public Animator animator;
    private Animator _currentPlayer;

    [Header("Jump Collision Check")]
    public Collider2D collider2d;
    public float distanceToGround;
    public float spaceToGround = .1f;
    public ParticleSystem jumpParticles;


    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }
        
        _currentPlayer = Instantiate(soPlayerSetup.player, transform);

        if (collider2d != null)
        {
            distanceToGround = collider2d.bounds.extents.y;
        }
    }

    private bool IsGrounder()
    {
        Debug.DrawRay(transform.position, -Vector2.up, Color.magenta, distanceToGround + spaceToGround);
        return Physics2D.Raycast(transform.position, -Vector2.up, distanceToGround + spaceToGround);
    }

    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;

        _currentPlayer.SetTrigger(soPlayerSetup.triggerDeath);

    }


    private void Update()
    {
        IsGrounder();
        MovimentJump();
        Movimentxy();
    }

    private void Movimentxy()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = soPlayerSetup.speedRun;
            _currentPlayer.SetBool(soPlayerSetup.boolFast, true);

        }
        else
            _currentSpeed = soPlayerSetup.speed;



        //_isRunning = Input.GetKey(KeyCode.LeftControl);

        if (Input.GetKey(KeyCode.A))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);

            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, soPlayerSetup.playerSwipeDuration);
            }
            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);


        }

        else if (Input.GetKey(KeyCode.D))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);

            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, soPlayerSetup.playerSwipeDuration);
            }

            //myRigidbody.velocity = new Vector2(Input.GetKey(KeyCode.LeftControl) ? speedRun : speed, myRigidbody.velocity.y);
            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);

            // ? = Se ele for verdadeiro, usa speedRun, se não, usa speed
        }
        else
        {
            _currentPlayer.SetBool(soPlayerSetup.boolRun, false);
        }

        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += soPlayerSetup.friction;
        }

        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= soPlayerSetup.friction;
        }
    }

    private void MovimentJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounder())
        {
            myRigidbody.velocity = Vector2.up * soPlayerSetup.forceJump;
            myRigidbody.transform.localScale = Vector2.one;
            DOTween.Kill(myRigidbody.transform);
            ScaleJump();
            PlayJumpVFX();
        }
    }

    private void PlayJumpVFX()
    {
        if (jumpParticles != null) jumpParticles.Play();
    }

    private void ScaleJump()
    {
        myRigidbody.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        myRigidbody.transform.DOScaleX(soPlayerSetup.jumpScaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

}
