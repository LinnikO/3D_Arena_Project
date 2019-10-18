using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    private Transform targetTransfor;
    private Vector3 targetPoint;
    private EnemyWeaponController weaponController;

    public void Launch(Transform target, EnemyWeaponController weaponController) {
        this.targetTransfor = target;
        this.weaponController = weaponController;
        this.weaponController.PlayerTeleported += OnPlayerTeleported;
    }

    public void OnPlayerTeleported() {     
        targetTransfor = null;
    }

    private void Update()
    {
        if (targetTransfor != null)
        {
            targetPoint = targetTransfor.position;   
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);

        if (targetTransfor == null && transform.position == targetPoint)
        {
            Destroy(this.gameObject);
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


    private void OnDestroy()
    {
        weaponController.PlayerTeleported -= OnPlayerTeleported;
    }
}
