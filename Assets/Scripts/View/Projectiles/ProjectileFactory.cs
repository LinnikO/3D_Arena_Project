using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactory : MonoBehaviour, IProjectileFactory
{
    [SerializeField] GameObject playerProjectilePref;
    [SerializeField] GameObject enemyProjectilePref;

    public Projectile CreateProjectile(ProjectileType type) {
        switch (type)
        {
            case ProjectileType.PLAYER:
                return Instantiate(playerProjectilePref).GetComponent<Projectile>();
            case ProjectileType.ENEMY:
                return Instantiate(enemyProjectilePref).GetComponent<Projectile>();
            default:
                return null;
        }
    }
}
