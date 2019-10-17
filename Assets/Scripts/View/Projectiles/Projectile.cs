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

    private void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }
}


public enum ProjectileType {
    PLAYER,
    ENEMY
}
