using strange.extensions.mediation.impl;

public class PauseButtonMediator : Mediator
{
    [Inject]
    public PauseButtonView View { get; set; }

    [Inject]
    public PauseButtonSignal PauseButtonSignal { get; set; }

    public override void OnRegister()
    {
        View.ButtonPressed += OnPauseButtonPressed;
    }

    public override void OnRemove()
    {
        View.ButtonPressed -= OnPauseButtonPressed;
    }

    private void OnPauseButtonPressed() {
        PauseButtonSignal.Dispatch();
    }
}
