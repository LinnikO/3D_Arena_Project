using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    private Transform target;

    public void Launch(Transform target) {
        this.target = target;
    }

    private void Update()
    {
        if (target != null) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            PlayerView player = collision.transform.GetComponent<PlayerView>();
            player.TakeDamage(damage);
            Destroy(this.gameObject);
        }
        else if (collision.transform.tag == "Obstacle")
        {
            Destroy(this.gameObject);
        }
    }
}
