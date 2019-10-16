using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyViewMediator : Mediator
{
    [Inject]
    public EnemyView View { get; set; }

    [Inject]
    public EnemyKilledSignal EnemyKilledSignal { get; set; }

    [Inject]
    public UltimateUsedSignal UltimateUsedSignal { get; set; }

    public override void OnRegister()
    {
        View.EnemyKilled += OnEnemyKilled;
        UltimateUsedSignal.AddListener(OnUltimateUsed);
    }

    public override void OnRemove()
    {
        View.EnemyKilled -= OnEnemyKilled;
        UltimateUsedSignal.RemoveListener(OnUltimateUsed);
    }

    private void OnEnemyKilled(EnemyType enemyType, bool addPoints)
    {
        EnemyKilledSignal.Dispatch(enemyType, addPoints);
    }

    private void OnUltimateUsed()
    {
        View.OnUltimateUsed();
    }
}
