using strange.extensions.mediation.impl;
using UnityEngine;
using System;

public class InputView : View
{
    public event Action<Vector2> MoveAxisChanged;
    public event Action<Vector2> LookAxisChanged;
    public event Action<bool> FireButtonChanged;

    [SerializeField] FixedJoystick joystick;
    [SerializeField] FixedTouchField touchField;
    [SerializeField] FixedButton fireButton;

    private Vector2 moveAxis;
    private Vector2 lookAxis;
    private bool fireButtonPressed;

    public Vector2 MoveAxis {
        get { return moveAxis; }
        set {
            if (moveAxis != value) {
                moveAxis = value;
                if (MoveAxisChanged != null) {
                    MoveAxisChanged(moveAxis);
                }
            }
        }
    }
    public Vector2 LookAxis {
        get { return lookAxis; }
        set
        {
            if (lookAxis != value)
            {
                lookAxis = value;
                if (LookAxisChanged != null)
                {
                    LookAxisChanged(lookAxis);
                }
            }
        }
    }
    public bool FireButtonPressed
    {
        get { return fireButtonPressed; }
        set
        {
            if (fireButtonPressed != value)
            {
                fireButtonPressed = value;
                if (FireButtonChanged != null)
                {
                    FireButtonChanged(fireButtonPressed);
                }
            }
        }
    }

    private void Update()
    {
        MoveAxis = joystick.Direction;
        LookAxis = touchField.TouchDist;
        FireButtonPressed = fireButton.Pressed;
    }
}
