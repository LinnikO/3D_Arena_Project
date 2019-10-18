using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyView : View
{
    public event Action<EnemyType, bool> EnemyKilled;
    public event Action<EnemyView> Destroyed;

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
            }
            if (health > fullHealth)
            {
                health = fullHealth;
            }
        }
    }

    protected override void Start()
    {
        base.Start();
        Health = fullHealth;
        if (weaponController != null) {          
            weaponController.Fire = true;
        }
    }

    public void TakeDamage(int damage, bool afterRecochet)
    {       
        if (Health > 0)
        {
            Health -= damage;
            if (Health == 0) {
                OnDeath(afterRecochet);
            }
        }
    }

    public void OnUltimateUsed()
    {
        Destroy(this.gameObject);
    }

    private void OnDeath(bool afterRecochet)
    {       
        if (EnemyKilled != null)
        {           
            EnemyKilled(type, afterRecochet);
        }
        Destroy(this.gameObject);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (Destroyed != null) {
            Destroyed(this);
        }
    }
}
