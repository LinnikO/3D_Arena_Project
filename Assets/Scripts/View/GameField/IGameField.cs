using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameField 
{
    EnemyView FindeNearestEnemy();
    Vector3 FindPlayerTeleportPosition();
}
