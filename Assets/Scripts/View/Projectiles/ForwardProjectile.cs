using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardProjectile : Projectile
{
    private Vector3 direction;

    public void Launch(Vector3 direction, Owner owner)
    {
        this.direction = direction;
        this.owner = owner;
    }

    private void Update()
    {
        if (direction != Vector3.zero)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
