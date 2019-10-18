using strange.extensions.command.impl;
using UnityEngine.SceneManagement;

public class RestartCommand : Command
{
    public override void Execute()
    {
        SceneManager.LoadScene("Game");
    }
}
