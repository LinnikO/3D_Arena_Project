using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameModel
{
    bool GameOn { get; set; }

    int EnemiesKilled { get; set; }

}
