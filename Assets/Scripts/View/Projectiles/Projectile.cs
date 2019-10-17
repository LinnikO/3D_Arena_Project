using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float lifeTime;

    protected Owner owner;

    private void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (owner == Owner.PLAYER && collision.transform.tag == "Enemy")
        {
            EnemyView enemy = collision.transform.GetComponent<EnemyView>();
            enemy.TakeDamage(damage);
        }
        else if (owner == Owner.ENEMY && collision.transform.tag == "Player")
        {
            PlayerView player = collision.transform.GetComponent<PlayerView>();
            player.TakeDamage(damage);
        }      
        Destroy(this.gameObject);
    }


}

public enum Owner {
    PLAYER,
    ENEMY
}

public enum ProjectileType {
    FORWARD,
    CHASE
}
