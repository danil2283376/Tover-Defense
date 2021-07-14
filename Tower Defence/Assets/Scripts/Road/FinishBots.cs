using UnityEngine;
using UnityEngine.UI;

public class FinishBots : MonoBehaviour
{
    public HealthPoint HealthPointPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            IEnemy enemy = collision.gameObject.GetComponent<IEnemy>();
            if (enemy != null)
            {
                HealthPointPlayer.SubstractHealth(enemy.GetDamage());
                Destroy(collision.gameObject);
            }
        }
    }
}
