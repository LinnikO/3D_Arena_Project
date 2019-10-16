using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyView : View
{
    public event Action<EnemyType, bool> EnemyKilled;

    [SerializeField] int fullHealth;   
    [SerializeField] EnemyType type;

    private int health;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            if (health <= 0)
            {
                health = 0;
                OnDeath(true);
            }
            if (health > fullHealth)
            {
                health = fullHealth;
            }
        }
    }

    protected override void OnEnable()
    {
        Health = fullHealth;
    }

    public void TakeDamage(int damage)
    {
        if (Health > 0)
        {
            Health -= damage;
        }
    }

    public void OnUltimateUsed()
    {
        OnDeath(false);
    }

    private void OnDeath(bool addPoints)
    {
        if (EnemyKilled != null)
        {           
            EnemyKilled(type, addPoints);
        }
        Destroy(this.gameObject);
    }
}
