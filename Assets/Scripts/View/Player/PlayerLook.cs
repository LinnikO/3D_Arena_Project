using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] Transform playerRoot;
    [SerializeField] Transform lookRoot;
    [SerializeField] bool invert;
    [SerializeField] bool canUnlock = true;
    [SerializeField] float sensivity = 5f;
    [SerializeField] int smoothSteps = 10;
    [SerializeField] float smooth_Weight = 0.4f;
    [SerializeField] float rollAngle = 10f;
    [SerializeField] float rollSpeed = 3f;
    [SerializeField] Vector2 defaultLookLimits = new Vector2(-70f, 80f);

    private Vector2 lookAngles;

    public Vector2 LookAxis { get; set; }

    void Update()
    {
        LookAround();
    }

    void LookAround()
    {
        lookAngles.x += LookAxis.x * sensivity * (invert ? 1f : -1f);
        lookAngles.y += LookAxis.y * sensivity;

        lookAngles.x = Mathf.Clamp(lookAngles.x, defaultLookLimits.x, defaultLookLimits.y);

        lookRoot.localRotation = Quaternion.Euler(lookAngles.x, 0f, 0f);
        playerRoot.localRotation = Quaternion.Euler(0f, lookAngles.y, 0f);
    }
}
