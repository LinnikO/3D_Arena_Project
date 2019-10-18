using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyView : View
{
    [SerializeField] Slider energySlider;

    public void SetEnergy(int energy, int fullEnergy)
    {
        float value = (float)energy / fullEnergy;
        energySlider.value = value;
    }
}
