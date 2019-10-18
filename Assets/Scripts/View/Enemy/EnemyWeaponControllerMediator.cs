using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponControllerMediator : Mediator
{
    [Inject]
    public EnemyWeaponController View { get; set; }

    [Inject]
    public PlayerTeleportedSignal PlayerTeleportedSignal { get; set; }

    public override void OnRegister()
    {
        PlayerTeleportedSignal.AddListener(OnPlayerTeleported);
    }

    public override void OnRemove()
    {
        PlayerTeleportedSignal.RemoveListener(OnPlayerTeleported);
    }

    private void OnPlayerTeleported() {
        View.OnPlayerTeleported();
    }
}
