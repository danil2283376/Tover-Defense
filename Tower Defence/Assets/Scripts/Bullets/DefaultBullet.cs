using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DefaultBullet : MonoBehaviour, IBullet
{
    public float Speed;

    private int Damage;
    private Vector2 _directionBullet;
    private Rigidbody2D _rigidbody2D;
    private void Start()
    {
        this._rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody2D.velocity.magnitude > Speed)
            this._rigidbody2D.velocity = _rigidbody2D.velocity.normalized * Speed;
        this._rigidbody2D.AddForce(_directionBullet * Speed, ForceMode2D.Impulse);
    }

    public void SetDirectionForSpawn(Vector2 direction)
    {
        this._directionBullet = direction;
    }

    public void SetDamageForSpawn(int damage) 
    {
        this.Damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            IEnemy enemy = collision.gameObject.GetComponent<IEnemy>();
            if (enemy != null)
            {
                enemy.InflictDamage(Damage);
                Destroy(gameObject);
            }
        }
    }
}
