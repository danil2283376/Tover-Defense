using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthPoint : MonoBehaviour
{
    public Image HealthBar;
    public int MaxHP;
    
    private int _currentHP;

    private int CurrentHP 
    {
        get 
        {
            return (this._currentHP);
        }
        set 
        {
            this._currentHP = value;
            if (this._currentHP <= 0)
            {
                this._currentHP = 0;
                DiePlayer();
            }
            UpdateHealthBar();
        }
    }
    private void Start()
    {
        _currentHP = MaxHP;    
    }

    public void SubstractHealth(int amount) 
    {
        if (amount < 0)
            throw new InvalidOperationException("Amount not be is negative number!");
        CurrentHP -= amount;
    }

    private void UpdateHealthBar() 
    {
        HealthBar.fillAmount = (((float)_currentHP * 100f) / (float)MaxHP) / 100f;
    }

    private void DiePlayer() 
    {
        Time.timeScale = 0f;
    }
}
