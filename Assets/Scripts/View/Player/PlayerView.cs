using strange.extensions.mediation.impl;
using UnityEngine;
using System;

public class PlayerView : View
{
    public event Action PlayerKilled;
    public event Action UltimateUsed;
 
    [SerializeField] int fullHealth;
    [SerializeField] int fullEnergy;
    [SerializeField] int startEnergy;
    [SerializeField] int blueEnemyReward;
    [SerializeField] int redEnemyReward;
    [SerializeField] PlayerMove playerMove;
    [SerializeField] PlayerLook mouseLook;
    [SerializeField] WeaponController weaponController;

    private int health;
    private int energy;
    private bool fire;

    [Inject]
    public IProjectileFactory ProjectileFactory { get; set; }

    public int Health {
        get { return health; }
        set {
            health = value;
            if (health <= 0)
            {
                health = 0;
                OnDeath();
            }
            if (health > fullHealth)
            {
                health = fullHealth;
            }
        }
    }

    public int Energy
    {
        get { return energy; }
        set
        {
            health = value;
            if (energy <= 0)
            {
                energy = 0;
            }
            if (energy > fullEnergy)
            {
                energy = fullEnergy;
            }
        }
    }

    protected override void Start()
    {
        base.Start();
        Health = fullHealth;
        Energy = startEnergy;     
    }

    public void SetMoveAxis(Vector2 moveAxis) {
        if (Health > 0)
        {
            playerMove.SetMoveDirection(new Vector3(moveAxis.x, 0, moveAxis.y));
        }
    }

    public void SetLookAxis(Vector2 lookAxis) {
        if (Health > 0)
        {
            mouseLook.LookAxis = new Vector2(lookAxis.y, lookAxis.x);
        }
    }

    public void Fire(bool fire) {
        if (Health > 0)
        {
            weaponController.Fire = fire;
        }
    }

    public void UseUltimate() {
        if (Health > 0 && Energy == fullEnergy)
        {
            Energy = 0;
            if (UltimateUsed != null) {
                UltimateUsed();
            }
        }
    }

    public void TakeDamage(int damage) {
        if (Health > 0) {
            Health -= damage;
        }
    }

    public void OnEnemyKilled(EnemyType type, bool addPoints) {
        if (Health > 0 && addPoints)
        {
            switch (type)
            {
                case EnemyType.BLUE:
                    Energy += blueEnemyReward;
                    break;
                case EnemyType.RED:
                    Energy += redEnemyReward;
                    break;
            }
        }
    }

    private void OnDeath() {
        playerMove.SetMoveDirection(Vector3.zero);
        mouseLook.LookAxis = Vector2.zero;
        weaponController.Fire = false;
        if (PlayerKilled != null)
        {
            PlayerKilled();
        }
    }
}
