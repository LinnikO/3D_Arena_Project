using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [HideInInspector]
    public List<EnemyView> enemies;

    [SerializeField] float maxSpawnTime;
    [SerializeField] float minSpawnTime;
    [SerializeField] float reduceSpawnTimeStep;

    private GameFieldInfo gameFieldInfo;
    private int spawnedEnemies;
    private float spawnTime;
    private float lastSpawnTime;
    private IEnemyFactory enemyFactory;

    public bool Initialized { get; private set; }

    public void Init(GameFieldInfo gameFieldInfo, IEnemyFactory enemyFactory) { 
        this.gameFieldInfo = gameFieldInfo;
        this.enemyFactory = enemyFactory;
        spawnedEnemies = 0;
        spawnTime = maxSpawnTime;
        lastSpawnTime = Time.time;
        enemies = new List<EnemyView>();
        Initialized = true;
    }

    private void Update()
    {
        if (Initialized && Time.time - lastSpawnTime > spawnTime) {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        spawnedEnemies++;
        lastSpawnTime = Time.time;
        spawnTime -= reduceSpawnTimeStep;
        if (spawnTime < minSpawnTime) {
            spawnTime = minSpawnTime;
        }

        EnemyType enemyType = spawnedEnemies % 5 == 0 ? EnemyType.BLUE : EnemyType.RED;
        EnemyView enemy = enemyFactory.CreateEnemy(enemyType);
        enemy.transform.position = GetRandomSpwanPosition(enemy);
        enemy.Destroyed += OnEnemyDestroyed;
        enemies.Add(enemy);
    }

    private Vector3 GetRandomSpwanPosition(EnemyView enemy) {
        Vector3 position = gameFieldInfo.spawnPositions[Random.Range(0, gameFieldInfo.spawnPositions.Count)].position;
        position.y = position.y + 0.3f;
        return position;
    }

    private void OnEnemyDestroyed(EnemyView enemy)
    {
        enemies.Remove(enemy);
    }

}
