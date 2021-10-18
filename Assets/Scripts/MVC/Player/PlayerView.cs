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
    public float currentScore;
    public UnityEvent OnZeroLives;

    [Header("References")]
    [SerializeField] private UIView ui;

    private void Start()
    {
        currentGold = Model.startingGold;
        currentLives = Model.startingLives;

        ui.SetLife(currentLives);
        ui.SetGold(currentGold);
        ui.SetScore(currentScore);
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

    public void AddScore(float amount)
    {
        currentScore += amount;
        ui.SetScore(currentScore);
    }
}
