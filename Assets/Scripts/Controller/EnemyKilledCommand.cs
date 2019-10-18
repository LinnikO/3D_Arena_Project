using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilledCommand : Command
{
    [Inject]
    public IGameModel GameModel { get; set; }
   
    public override void Execute()
    {
        GameModel.EnemiesKilled++;
    }
}
