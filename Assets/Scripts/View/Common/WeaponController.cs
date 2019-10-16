using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour
{
    [SerializeField] float cooldown;

    private float shootTime;

    public bool Fire { get; set; }

    private void Start()
    {
        shootTime = Time.time;
    }

    private void Update()
    {
        if (Fire && Time.time - shootTime >= cooldown) {
            Shoot();
        }
    }

    protected abstract void Shoot();
   
}
