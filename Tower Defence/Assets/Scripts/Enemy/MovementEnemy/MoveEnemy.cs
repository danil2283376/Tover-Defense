using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveEnemy : MonoBehaviour, IDirection
{
    public EnemyObject EnemyObject;
    public Vector2 Direction;
    public float Speed;

    private Rigidbody2D _rigidbody2D;
    private void Start()
    {
        if (Speed == 0)
            throw new InvalidOperationException("Speed = 0, bot stay in 1st place!");
        if (Direction == new Vector2(0, 0))
            throw new InvalidOperationException("Direction = (0,0), bot stay in 1st place!");
        this._rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        if (this._rigidbody2D == null)
            throw new InvalidOperationException("RigidBody2D not set on enemy");
    }

    private void FixedUpdate()
    {
        if (_rigidbody2D.velocity.magnitude > Speed)
            _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * Speed;
        _rigidbody2D.AddForce(Direction * Speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    public void ChangeDirection(Vector2 direction) 
    {
        if (direction == null)
            throw new InvalidOperationException("Direction not be null!");
        if (_rigidbody2D != null)
            this._rigidbody2D.velocity = Vector2.zero;
        this.Direction = direction;
    }
}
