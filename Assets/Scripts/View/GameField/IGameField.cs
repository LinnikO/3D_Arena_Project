using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameField 
{
    GameFieldInfo GameFieldInfo { get; }
    EnemyView FindeNearestEnemy(EnemyView hitedEnemy);
    Vector3 FindPlayerTeleportPosition();
}
