using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItenCollectableBase : MonoBehaviour
{

    public string comparteTag = "Player";


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag(comparteTag))
        {
            Collect();
        }

    }

    protected virtual void Collect()
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        gameObject.SetActive(false);
        OnCollect();
    }

    protected virtual void OnCollect()
    {
        
    }

    /* public class ItemCollactableCoin : ItenCollectableBase
     {

     } */
}
