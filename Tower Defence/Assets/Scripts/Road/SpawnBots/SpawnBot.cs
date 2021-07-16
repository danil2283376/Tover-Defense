using System;
using UnityEngine;

public class SpawnBot : MonoBehaviour
{
    public GameObject ParrentForBots;
    public EnemyObject[] EnemyObjects;
    public Vector2 DirectionBotWhenSpawn;
    public float TimeSpawnWave;

    private float _currentTime = 0f;
    private void Start()
    {
        if (ParrentForBots == null)
            throw new InvalidOperationException("Please set parrent for bots!");
        if (EnemyObjects.Length == 0)
            throw new InvalidOperationException("Please set enemy Object!");
        if (DirectionBotWhenSpawn == Vector2.zero)
            throw new InvalidOperationException("Direction when spawn = (0,0), bot just stay in 1st place");
        if (TimeSpawnWave == 0f)
            throw new InvalidOperationException("Bots never spawns!");
        for (int enemy = 0; enemy < EnemyObjects.Length; enemy++)
        {
            if (EnemyObjects[enemy] == null)
                throw new InvalidOperationException("Enemy null!");
        }
    }

    private void Update()
    {
        if (_currentTime >= TimeSpawnWave)
            CheckTimeForRespawn();
        _currentTime += Time.deltaTime;
    }

    private void CheckTimeForRespawn()
    {
        for (int enemy = 0; enemy < EnemyObjects.Length; enemy++)
        {
            Spawn(EnemyObjects[enemy].PrefabEnemy);
        }
        _currentTime = 0f;
    }

    private void Spawn(GameObject enemy)
    {
        Vector3 newPositionEnemy = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,
            0);
        GameObject createEnemy = Instantiate(enemy, newPositionEnemy, 
            Quaternion.identity, ParrentForBots.transform);
        if (createEnemy == null)
            throw new InvalidOperationException("Enemy not create!");
        SetDirectionBot(createEnemy);
    }

    private void SetDirectionBot(GameObject enemy) 
    {
        IDirection directionBot = enemy.GetComponent<IDirection>();
        if (directionBot == null)
            throw new InvalidOperationException("On bot not set MoveEnemy!");
        directionBot.ChangeDirection(DirectionBotWhenSpawn);
    }
}
