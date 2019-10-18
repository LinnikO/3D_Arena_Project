using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMediator : Mediator
{
    [Inject]
    public PlayerMove View { get; set; }

    [Inject]
    public PlayerTeleportedSignal PlayerTeleportedSignal { get; set; }

    
    public override void OnRegister()
    {
        View.PlayerTeleported += OnPlayerTeleported;
    }

    public override void OnRemove()
    {
        View.PlayerTeleported -= OnPlayerTeleported;
    }

    private void OnPlayerTeleported()
    {
        PlayerTeleportedSignal.Dispatch();
    }    
}
