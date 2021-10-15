using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerView : BaseView<PlayerModel, PlayerController>
{
    public PlayerBase playerBase;
    public int currentLives;
    public float currentGold;
    public UnityEvent OnZeroLives;

    [Header("References")]
    [SerializeField] private UIView ui;

    private void Start()
    {
        currentGold = Model.startingGold;
        currentLives = Model.startingLives;

        ui.SetGold(currentGold);
        ui.SetLife(currentLives);
    }

    public void RegisterEvents(UIView ui)
    {
        playerBase.OnBaseHit += (damage)=> {
            DecreaseLife(damage);
            ui.SetLife(currentLives);
        };
    }

    public bool HasEnoughCoins(float amount)
    {
        return (currentGold >= amount);
    }

    public void SpendCoins(float amount)
    {
        currentGold -= amount;
        ui.SetGold(currentGold);
    }

    public void AddCoins(float amount)
    {
        currentGold += amount;
        ui.SetGold(currentGold);
    }

    public void DecreaseLife(int damageReceived)
    {
        currentLives -= damageReceived;
        if(currentLives == 0)
        {
            OnZeroLives?.Invoke();
        }
    }
}
