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
    [SerializeField] WeaponController weaponController;

    private int health;

    [Inject]
    public IProjectileFactory ProjectileFactory { get; set; }

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

    protected override void Start()
    {
        Health = fullHealth;
        if (weaponController != null) {
            weaponController.Init(ProjectileFactory);
            weaponController.Fire = true;
        }
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
