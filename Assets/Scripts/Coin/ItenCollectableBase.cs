using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItenCollectableBase : MonoBehaviour
{

    public string comparteTag = "Player";
    public ParticleSystem particleSystem;
    public float timeToHide;
    public GameObject itemGraphic;

    private void Awake()
    {
      if (particleSystem != null) particleSystem.transform.SetParent(null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag(comparteTag))
        {
            Collect();
        }

    }
    
    private void HideObject() 
    {
        gameObject.SetActive(false);

    }

    protected virtual void Collect()
    {
        if (itemGraphic != null) itemGraphic.SetActive(false);
        Invoke("HideObject", timeToHide);
        OnCollect();
    }

    protected virtual void OnCollect()
    {
        if (particleSystem != null) particleSystem.Play();
    }

    /* public class ItemCollactableCoin : ItenCollectableBase
     {

     } */
}
