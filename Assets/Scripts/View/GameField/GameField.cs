using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour, IGameField
{
    [SerializeField] GameFieldInfo gameFieldInfo;
    [SerializeField] EnemiesSpawner enemiesSpawner;
    [SerializeField] EnemyFactory enemyFactory;

    private void Start()
    { 
        enemiesSpawner.Init(gameFieldInfo, enemyFactory);
    }

    public EnemyView FindeNearestEnemy() {
        EnemyView nearestEnemy = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (EnemyView enemy in enemiesSpawner.enemies)
        {
            Vector3 directionToTarget = enemy.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    public Vector3 FindPlayerTeleportPosition() {
        float y = gameFieldInfo.center.y + 1f;
        float x = gameFieldInfo.center.x + Random.Range(-gameFieldInfo.radius, gameFieldInfo.radius);
        float z = gameFieldInfo.center.z + Random.Range(-gameFieldInfo.radius, gameFieldInfo.radius);
        return new Vector3(x, y, z);
    }

}
