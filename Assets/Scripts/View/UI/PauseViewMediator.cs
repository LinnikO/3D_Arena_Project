using strange.extensions.mediation.impl;

public class PauseViewMediator : Mediator
{
    [Inject]
    public PauseView View { get; set; }

    [Inject]
    public ShowPauseSignal ShowPauseSignal { get; set; }

    [Inject]
    public RestartButtonSignal RestartButtonSignal { get; set; }

    [Inject]
    public PauseClosedSignal PauseClosedSignal { get; set; }

    public override void OnRegister()
    {
        ShowPauseSignal.AddListener(OnShowPause);
        View.RestartButton += OnRestartButton;
        View.CloseButton += OnCloseButton;
    }

    public override void OnRemove()
    {
        ShowPauseSignal.RemoveListener(OnShowPause);
        View.RestartButton -= OnRestartButton;
        View.CloseButton -= OnCloseButton;
    }

    private void OnShowPause(int enemiesKilled)
    {
        View.Show(enemiesKilled);
    }

    private void OnRestartButton()
    {
        RestartButtonSignal.Dispatch();
    }

    private void OnCloseButton() {
        PauseClosedSignal.Dispatch();
    }
}
