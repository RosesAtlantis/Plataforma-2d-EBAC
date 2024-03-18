using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public ProjectileBase prefabProjectile;

    public float timeToBetweenShot;

    private Coroutine _currentCourotine;

    public Transform playerSideReference;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _currentCourotine = StartCoroutine(StartShoot());
        }

        else if(Input.GetKeyUp(KeyCode.S))
            {
            if (_currentCourotine != null) StopCoroutine(_currentCourotine);
            }
    }

    IEnumerator StartShoot()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeToBetweenShot);
        }
    }
    public Transform positionToShoot;

    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = playerSideReference.transform.localScale.x;

    }
}
