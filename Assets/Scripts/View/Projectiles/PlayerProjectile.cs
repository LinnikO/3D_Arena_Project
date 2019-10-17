using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyView enemy = other.transform.GetComponent<EnemyView>();

            enemy.TakeDamage(damage, afterRecochet);
            if (recochet)
            {
                recochet = false;
                afterRecochet = true;
                MoveToNearestEnemy(enemy);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        else if (other.tag == "Obstacle")
        {
            Destroy(this.gameObject);
        }
    }

    private void MoveToNearestEnemy(EnemyView hitedEnemy) {
        EnemyView enemy = gameField.FindeNearestEnemy(hitedEnemy);
        if (enemy != null)
        {
            direction = (enemy.transform.position - transform.position).normalized;
        }
        else {
            Destroy(this.gameObject);
        }
    }
}
