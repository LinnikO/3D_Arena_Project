using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : WeaponController
{
    protected override void Shoot()
    {
        print("Player shoot");
    }
}
