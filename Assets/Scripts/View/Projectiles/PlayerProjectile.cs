using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
    [SerializeField] int recochetDamage;

    private Vector3 direction;
    private bool recochet;
    private IGameField gameField;
    private bool afterRecochet;

    public void Launch(Vector3 direction, bool recochet, IGameField gameField)
    {
        this.direction = direction;    
        this.recochet = recochet;
        this.gameField = gameField;
    }

    private void Update()
    {
        if (direction != Vector3.zero)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            EnemyView enemy = collision.transform.GetComponent<EnemyView>();
            int damageToEnemy = afterRecochet ? recochetDamage : damage;

            if (recochet)
            {
                enemy.TakeDamage(damageToEnemy, afterRecochet);
                recochet = false;
                afterRecochet = true;
                MoveToNearestEnemy();
            }
            else
            {
                enemy.TakeDamage(damageToEnemy, afterRecochet);
                Destroy(this.gameObject);
            }
        }
        else if (collision.transform.tag == "Obstacle")
        {
            Destroy(this.gameObject);
        }
    }

    private void MoveToNearestEnemy() {
        Transform enemy = gameField.FindeNearestEnemy().transform;
        direction = (enemy.position - transform.position).normalized;
    }
}
