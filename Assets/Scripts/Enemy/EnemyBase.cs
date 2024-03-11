using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        var health = collision.gameObject.GetComponent<HealthBase>();


        if(health != null)
        {
            health.Damage(damage);
        }
    }
}
