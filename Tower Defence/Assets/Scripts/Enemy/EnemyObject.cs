using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy")]
public class EnemyObject : ScriptableObject
{
    public int countRespawn;
    public int Damage;
    public GameObject PrefabEnemy;
}
