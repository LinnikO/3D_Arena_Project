using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewMediator : Mediator
{
    [Inject]
    public PlayerView View { get; set; }

    [Inject]
    public MoveAxisSignal MoveAxisSignal { get; set; }

    [Inject]
    public LookAxisSignal LookAxisSignal { get; set; }

    [Inject]
    public FireButtonSignal FireButtonSignal { get; set; }

    [Inject]
    public UltimateButtonSignal UltimateButtonSignal { get; set; }

    [Inject]
    public EnemyKilledSignal EnemyKilledSignal { get; set; }

    [Inject]
    public PlayerKilledSignal PlayerKilledSignal { get; set; }

    [Inject]
    public UltimateUsedSignal UltimateUsedSignal { get; set; }

    public override void OnRegister()
    {
        MoveAxisSignal.AddListener(OnMoveAxisSignal);
        LookAxisSignal.AddListener(OnLookAxisSignal);
        FireButtonSignal.AddListener(OnFireButtonSignal);
        UltimateButtonSignal.AddListener(OnUltimateButtonSignal);
        EnemyKilledSignal.AddListener(OnEnemyKilled);
        View.PlayerKilled += OnPlayerKilled;
        View.UltimateUsed += OnUltimateUsed;
    }

    public override void OnRemove()
    {
        MoveAxisSignal.RemoveListener(OnMoveAxisSignal);
        LookAxisSignal.RemoveListener(OnLookAxisSignal);
        FireButtonSignal.RemoveListener(OnFireButtonSignal);
        UltimateButtonSignal.RemoveListener(OnUltimateButtonSignal);
        EnemyKilledSignal.RemoveListener(OnEnemyKilled);
        View.PlayerKilled -= OnPlayerKilled;
        View.UltimateUsed -= OnUltimateUsed;
    }

    private void OnMoveAxisSignal(Vector2 moveDirection)
    {
        View.SetMoveAxis(moveDirection);
    }

    private void OnLookAxisSignal(Vector2 lookDirection)
    {
        View.SetLookAxis(lookDirection);
    }

    private void OnFireButtonSignal(bool pressed)
    {
        View.Fire(pressed);
    }

    private void OnUltimateButtonSignal() {
        View.UseUltimate();
    }

    private void OnEnemyKilled(EnemyType enemyType) {
        View.OnEnemyKilled(enemyType);
    }

    private void OnPlayerKilled() {
        PlayerKilledSignal.Dispatch();
    }

    private void OnUltimateUsed() {
        UltimateUsedSignal.Dispatch();
    }

}
