using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : WeaponController
{
    protected override void Shoot()
    {       
        EnemyProjectile projectile = ProjectileFactory.CreateProjectile(ProjectileType.ENEMY) as EnemyProjectile;
        projectile.transform.position = shootPosition.position;
        Transform playerTransform = FindObjectOfType<PlayerView>().transform;
        projectile.Launch(playerTransform);
    }
}
