using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputViewMediator : Mediator
{
    [Inject]
    public InputView View { get; set; }

    [Inject]
    public MoveAxisSignal MoveAxisSignal { get; set; }

    [Inject]
    public LookAxisSignal LookAxisSignal { get; set; }

    [Inject]
    public FireButtonSignal FireButtonSignal { get; set; }

    [Inject]
    public UltimateButtonSignal UltimateButtonSignal { get; set; }

    public override void OnRegister()
    {
        View.MoveAxisChanged += OnMoveAxisChanged;
        View.LookAxisChanged += OnLootAxisChanged;
        View.FireButtonChanged += OnFireButtontChanged;
        View.UltimateButtonPressed += OnUltimateButtonPressed;
    }

    public override void OnRemove()
    {
        View.MoveAxisChanged -= OnMoveAxisChanged;
        View.LookAxisChanged -= OnLootAxisChanged;
        View.FireButtonChanged -= OnFireButtontChanged;
        View.UltimateButtonPressed -= OnUltimateButtonPressed;
    }

    private void OnMoveAxisChanged(Vector2 moveDirection) {
        MoveAxisSignal.Dispatch(moveDirection);
    }

    private void OnLootAxisChanged(Vector2 lookDirection) {
        LookAxisSignal.Dispatch(lookDirection);
    }

    private void OnFireButtontChanged(bool pressed) {
        FireButtonSignal.Dispatch(pressed);
    }

    private void OnUltimateButtonPressed() {
        UltimateButtonSignal.Dispatch();
    }


}
