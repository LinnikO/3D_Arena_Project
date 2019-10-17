using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour, IEnemyFactory
{
    [SerializeField] GameObject blueEnemyPref;
    [SerializeField] GameObject redEnemyPref;

    public EnemyView CreateEnemy(EnemyType type) {
        switch (type)
        {
            case EnemyType.BLUE:
                return Instantiate(blueEnemyPref).GetComponent<EnemyView>();
            case EnemyType.RED:
                return Instantiate(redEnemyPref).GetComponent<EnemyView>();
            default:
                return null;
        }
    }
}
