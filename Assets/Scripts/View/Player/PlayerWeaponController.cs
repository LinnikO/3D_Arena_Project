using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : WeaponController
{
    protected override void Shoot()
    {
        ForwardProjectile projectile = projectileFactory.CreateProjectile(ProjectileType.FORWARD) as ForwardProjectile;
        projectile.transform.position = shootPosition.position;
        projectile.Launch(shootPosition.forward, Owner.PLAYER);
    }
}
