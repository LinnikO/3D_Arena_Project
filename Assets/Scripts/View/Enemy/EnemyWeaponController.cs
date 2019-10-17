using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : WeaponController
{
    protected override void Shoot()
    {       
        ChaseProjectile projectile = projectileFactory.CreateProjectile(ProjectileType.CHASE) as ChaseProjectile;
        projectile.transform.position = shootPosition.position;
        Transform playerTransform = FindObjectOfType<PlayerView>().transform;
        projectile.Launch(playerTransform, Owner.ENEMY);
    }
}
