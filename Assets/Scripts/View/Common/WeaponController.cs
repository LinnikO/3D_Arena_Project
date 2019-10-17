using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour
{
    [SerializeField]
    protected float cooldown;
    [SerializeField]
    protected Transform shootPosition;

    private float shootTime;

    public bool Fire { get; set; }
    public bool Initialized { get; private set; }

    protected IProjectileFactory projectileFactory;

    public void Init(IProjectileFactory projectileFactory)
    {
        shootTime = Time.time;
        this.projectileFactory = projectileFactory;
        Initialized = true;
    }

    private void Update()
    {
        if (Initialized && Fire && Time.time - shootTime >= cooldown) {
            shootTime = Time.time;
            Shoot();
        }
    }

    protected abstract void Shoot();
   
}
