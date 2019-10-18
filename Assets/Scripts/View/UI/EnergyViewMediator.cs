using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyViewMediator : Mediator
{
    [Inject]
    public EnergyView View { get; set; }

    [Inject]
    public EnergyChangedSignal EnergyChangedSignal { get; set; }

    public override void OnRegister()
    {
        EnergyChangedSignal.AddListener(OnEnergyChanged);
    }

    public override void OnRemove()
    {
        EnergyChangedSignal.RemoveListener(OnEnergyChanged);
    }

    private void OnEnergyChanged(int energy, int fullEnergy)
    {
        View.SetEnergy(energy, fullEnergy);
    }
}
