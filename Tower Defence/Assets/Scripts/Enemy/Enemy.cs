using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public EnemyObject EnemyObject;
    public int MaxHealthPoint;

    private int _currentHealthPoint { get; set; }
    public int CurrentHealthPoint
    {
        get 
        {
            return (_currentHealthPoint);
        }
        private set
        {
            this._currentHealthPoint = value;
            if (this._currentHealthPoint < 0)
            {
                this._currentHealthPoint = 0;
                DieEnemy();
            }
        }
    }

    private void Start()
    {
        if (MaxHealthPoint == 0)
            throw new InvalidOperationException("MaxHealthPoint = 0, enemy just die!");
        this._currentHealthPoint = MaxHealthPoint;
    }

    public void InflictDamage(int amount)
    {
        if (amount < 0)
            throw new InvalidOperationException("Amount not be is negative number!");
        CurrentHealthPoint -= amount;
    }

    public int GetDamage() 
    {
        return (this.EnemyObject.Damage);
    }

    private void DieEnemy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {

        }
    }
}