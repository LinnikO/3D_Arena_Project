using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDamage : MonoBehaviour
{
    [SerializeField] int damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player") {
            PlayerView player = collision.transform.GetComponent<PlayerView>();
            player.TakeDamage(damage);
        }
    }
}
