using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthViewMediator : Mediator
{
    [Inject]
    public HealthView View { get; set; } 

    [Inject]
    public HealthChangedSignal HealthChangedSignal { get; set; }

    public override void OnRegister()
    {
        HealthChangedSignal.AddListener(OnHealthChanged);
    }

    public override void OnRemove()
    {
        HealthChangedSignal.RemoveListener(OnHealthChanged);
    }

    private void OnHealthChanged(int health, int fullHealth) {      
        View.SetHealth(health, fullHealth);
    }
}
