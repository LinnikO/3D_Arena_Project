using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCommand : Command
{
    [Inject]
    public IGameModel GameModel { get; set; }

    public override void Execute()
    {
        GameModel.GameOn = true;
        GameModel.EnemiesKilled = 0;
    }
}
