using UnityEngine;

public class PlayerWeaponController : WeaponController
{
    [SerializeField] PlayerView player;

    protected override void Shoot()
    {
        PlayerProjectile projectile = ProjectileFactory.CreateProjectile(ProjectileType.PLAYER) as PlayerProjectile;
        projectile.transform.position = shootPosition.position;
        projectile.Launch(shootPosition.forward, ShoudProjectileRecochet(), GameField);
    }

    private bool ShoudProjectileRecochet() {
        float chance = 0.1f + (1f - (float)player.Health / player.FullHealth);        
        return Random.Range(0, 1f) < chance;
    }
}
