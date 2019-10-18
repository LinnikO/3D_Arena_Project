using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOnCommand : Command
{
    [Inject]
    public IGameModel GameModel { get; set; }

    [Inject]
    public ShowPauseSignal ShowPauseSignal { get; set; }

    public override void Execute()
    {
        GameModel.GameOn = false;
        Time.timeScale = 0;
        ShowPauseSignal.Dispatch(GameModel.EnemiesKilled);
    }
}
