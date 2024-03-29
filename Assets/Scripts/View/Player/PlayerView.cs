﻿using strange.extensions.mediation.impl;
using UnityEngine;
using System;

public class PlayerView : View
{
    public event Action PlayerKilled;
    public event Action UltimateUsed;
    public event Action<int, int> HealthChanged;
    public event Action<int, int> EnergyChanged;

    [SerializeField] int fullHealth;
    [SerializeField] int fullEnergy;
    [SerializeField] int startEnergy;
    [SerializeField] int blueEnemyReward;
    [SerializeField] int blueRecochetEnemyReward;
    [SerializeField] int redEnemyReward;
    [SerializeField] int redRecochetEnemyReward;
    [SerializeField] PlayerMove playerMove;
    [SerializeField] PlayerLook mouseLook;
    [SerializeField] WeaponController weaponController;

    private int health;
    private int energy;
    private bool fire;

    public int FullHealth {
        get { return fullHealth; }
    }

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
            OnHealthChanged();
        }
    }

    public int Energy
    {
        get { return energy; }
        set
        {
            energy = value;
            if (energy <= 0)
            {
                energy = 0;
            }
            if (energy > fullEnergy)
            {
                energy = fullEnergy;
            }
            OnEnergyChanged();
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

    public void OnEnemyKilled(EnemyType type, bool afterRecochet) {
        if (Health == 0)
        {
            return;
        }

        if (afterRecochet)
        {
            if (UnityEngine.Random.Range(0f, 1f) > 0.5f)
            {
                Health += fullHealth / 2;
            }
            else
            {
                switch (type)
                {
                    case EnemyType.BLUE:
                        Energy += blueRecochetEnemyReward;
                        break;
                    case EnemyType.RED:
                        Energy += redRecochetEnemyReward;
                        break;
                }
            }
        }
        else
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

    private void OnHealthChanged() {
        if (HealthChanged != null) {
            HealthChanged(health, fullHealth);
        }
    }

    private void OnEnergyChanged() {
        if (EnergyChanged != null) {
            EnergyChanged(energy, fullEnergy);
        }
    }
}
