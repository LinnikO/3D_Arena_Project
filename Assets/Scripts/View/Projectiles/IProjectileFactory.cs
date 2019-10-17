using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileFactory
{
    Projectile CreateProjectile(ProjectileType type);
}
