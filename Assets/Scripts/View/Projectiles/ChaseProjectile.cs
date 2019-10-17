using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseProjectile : Projectile
{
    private Transform target;

    public void Launch(Transform target, Owner owner) {
        this.target = target;
        this.owner = owner;
    }

    private void Update()
    {
        if (target != null) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

}
