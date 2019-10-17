using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyFactory
{
    EnemyView CreateEnemy(EnemyType type);
}
