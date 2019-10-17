using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponController : View
{
    [SerializeField]
    protected float cooldown;
    [SerializeField]
    protected Transform shootPosition;

    private float shootTime;

    public bool Fire { get; set; }

    [Inject]
    public IProjectileFactory ProjectileFactory { get; set; }

    [Inject]
    public IGameField GameField { get; set; }

    protected override void Start()
    {
        shootTime = Time.time;           
    }

    private void Update()
    {
        if (Fire && Time.time - shootTime >= cooldown) {
            shootTime = Time.time;
            Shoot();
        }
    }

    protected abstract void Shoot();
   
}
