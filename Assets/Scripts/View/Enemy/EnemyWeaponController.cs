using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : WeaponController
{
    private void Start()
    {
        Fire = true;
    }

    protected override void Shoot()
    {
        print("Enemy shoot");
    }
}
