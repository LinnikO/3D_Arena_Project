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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerView player = other.transform.GetComponent<PlayerView>();           
            player.TakeDamage(damage);
            Destroy(this.gameObject);
        }
        else if (other.tag == "Obstacle")
        {
            Destroy(this.gameObject);
        }
    }

}
