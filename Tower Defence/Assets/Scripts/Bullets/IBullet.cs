using UnityEngine;

public interface IBullet
{
    public void SetDirectionForSpawn(Vector2 direction);
    public void SetDamageForSpawn(int damage);
}