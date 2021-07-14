using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerDirectionRoad : MonoBehaviour
{
    public Vector2 ChangeDirectionBot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {

            if (collision != null)
            {
                IDirection directionEnemy = collision.gameObject.GetComponent<IDirection>();
                if (directionEnemy != null)
                    directionEnemy.ChangeDirection(ChangeDirectionBot);
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision != null)
    //    {
    //        IDirection directionEnemy = collision.gameObject.GetComponent<IDirection>();
    //        if (directionEnemy != null)
    //            directionEnemy.ChangeDirection(ChangeDirectionBot);
    //    }
    //    Debug.Log(collision.gameObject.name);
    //}
}