using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int damage;
    public Animator animator;
    public string triggerAttack = "Attack";

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
}
