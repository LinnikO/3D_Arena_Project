using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCommand : Command
{
    [Inject]
    public IGameModel GameModel { get; set; }

    [Inject]
    public ShowGameOverSignal ShowGameOverSignal { get; set;}

    public override void Execute()
    {
        GameModel.GameOn = false;
        ShowGameOverSignal.Dispatch(GameModel.EnemiesKilled);
    }
}
