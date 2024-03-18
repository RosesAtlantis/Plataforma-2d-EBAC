using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage;
    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerDeath = "Death";

    public HealthBase healthBase;

    public float timeToDestroy;

    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;
        PlayDeathAnimattion();
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        var health = collision.gameObject.GetComponent<HealthBase>();


        if(health != null)
        {
            health.Damage(damage);
            PlayAttackAnimattion();
        }
    }

    private void PlayAttackAnimattion()
    {
        animator.SetTrigger(triggerAttack);
    }

    private void PlayDeathAnimattion()
    {
        animator.SetTrigger(triggerDeath);
    }

    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }
}
