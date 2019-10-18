using UnityEngine;
using System;

public class EnemyWeaponController : WeaponController
{
    public event Action PlayerTeleported;

    public void OnPlayerTeleported() {
        if (PlayerTeleported != null) {
            PlayerTeleported();
        }
    }

    protected override void Shoot()
    {       
        EnemyProjectile projectile = ProjectileFactory.CreateProjectile(ProjectileType.ENEMY) as EnemyProjectile;
        projectile.transform.position = shootPosition.position;
        Transform playerTransform = FindObjectOfType<PlayerView>().transform;
        projectile.Launch(playerTransform, this);       
    }
}
