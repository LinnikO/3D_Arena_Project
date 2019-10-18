using strange.extensions.mediation.impl;

public class GameOverViewMediator : Mediator
{
    [Inject]
    public GameOverView View { get; set; }

    [Inject]
    public ShowGameOverSignal ShowGameOverSignal { get; set; }

    [Inject]
    public RestartButtonSignal RestartButtonSignal { get; set; }

    public override void OnRegister()
    {
        ShowGameOverSignal.AddListener(OnShowGameOver);
        View.RestartButton += OnRestartButton;
    }

    public override void OnRemove()
    {
        ShowGameOverSignal.RemoveListener(OnShowGameOver);
        View.RestartButton -= OnRestartButton;
    }

    private void OnShowGameOver(int enemiesKilled) {
        View.Show(enemiesKilled);
    }

    private void OnRestartButton() {
        RestartButtonSignal.Dispatch();
    }
}
