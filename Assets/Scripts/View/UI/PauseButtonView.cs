using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseButtonView : View
{
    public event Action ButtonPressed;

    public void OnButtonPressed() {
        if (ButtonPressed != null) {
            ButtonPressed();
        }
    }
}
