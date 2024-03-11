using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife;

    public bool destroyOnKill = false;
    private float delayToKill = 1f;

    private int _currentLife;

    private bool _isDead = false;

    private void Awake()
    {
        _currentLife = startLife;
    }

    private void Init()
    {
        _currentLife = startLife;
        _isDead = false;
}

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;

        if(_currentLife <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        _isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
    }
}
