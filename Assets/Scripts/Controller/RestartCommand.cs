using strange.extensions.command.impl;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartCommand : Command
{
    public override void Execute()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
}
