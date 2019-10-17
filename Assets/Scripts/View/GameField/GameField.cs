using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour, IGameField
{
    [SerializeField] GameFieldInfo gameFieldInfo;
    [SerializeField] EnemiesSpawner enemiesSpawner;
    [SerializeField] EnemyFactory enemyFactory;

    public GameFieldInfo GameFieldInfo {
        get { return gameFieldInfo; }
    }

    private void Start()
    { 
        enemiesSpawner.Init(gameFieldInfo, enemyFactory);
    }

    public EnemyView FindeNearestEnemy(EnemyView hitedEnemy) {
        EnemyView nearestEnemy = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (EnemyView enemy in enemiesSpawner.enemies)
        {
            if (enemy == hitedEnemy) {
                continue;
            }

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
        return gameFieldInfo.spawnPositions[Random.Range(0, gameFieldInfo.spawnPositions.Count)].position;
    }

}
