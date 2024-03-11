using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    [Header("Speed setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    private float _currentSpeed;
    private bool _isRunning = false;
    public float forceJump;

    [Header("Animation setup")]
    public float jumpScaleY;
    public float jumpScaleX;
    public float animationDuration;
    public Ease ease = Ease.OutBack;

    private void Update()
    {
        MovimentJump();
        Movimentxy();
    }

    private void Movimentxy()
    {
        /*if (Input.GetKey(KeyCode.LeftControl))
            _currentSpeed = speedRun;
        else
            _currentSpeed = speed;*/

        //_isRunning = Input.GetKey(KeyCode.LeftControl);

        if (Input.GetKey(KeyCode.A))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
           
            myRigidbody.velocity = new Vector2(Input.GetKey(KeyCode.LeftControl) ? -speedRun  : -speed, myRigidbody.velocity.y);
            
        }

        else if (Input.GetKey(KeyCode.D))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            //myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);

            myRigidbody.velocity = new Vector2(Input.GetKey(KeyCode.LeftControl) ? speedRun : speed, myRigidbody.velocity.y);
            // ? = Se ele for verdadeiro, usa speedRun, se n�o, usa speed
        }

        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += friction;
        }

        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= friction;
        }
    }

    private void MovimentJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
          {
            myRigidbody.velocity = Vector2.up * forceJump;
            myRigidbody.transform.localScale = Vector2.one;
            DOTween.Kill(myRigidbody.transform);
            ScaleJump();
          }
    }   
    private void ScaleJump()
    {
        myRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

}
