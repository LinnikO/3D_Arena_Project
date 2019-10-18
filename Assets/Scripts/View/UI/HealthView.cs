using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : View
{
    [SerializeField] Slider healthSlider;

    public void SetHealth(int health, int fullHealth) {
        float value = (float)health / fullHealth;
        healthSlider.value = value;
    }
}
