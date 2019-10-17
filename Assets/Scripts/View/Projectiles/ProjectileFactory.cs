using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactory : MonoBehaviour, IProjectileFactory
{
    [SerializeField] GameObject forwardProjectilePref;
    [SerializeField] GameObject chaseProjectilePref;

    public Projectile CreateProjectile(ProjectileType type) {
        switch (type)
        {
            case ProjectileType.FORWARD:
                return Instantiate(forwardProjectilePref).GetComponent<Projectile>();
            case ProjectileType.CHASE:
                return Instantiate(chaseProjectilePref).GetComponent<Projectile>();
            default:
                return null;
        }
    }
}
