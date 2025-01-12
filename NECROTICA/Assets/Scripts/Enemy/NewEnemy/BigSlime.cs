using UnityEngine;
using UnityEngine.AI;

public class BigSlime : BaseEnemy
{
    [SerializeField] private GameObject smallSlimePrefab;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private float spawnOffset = 1.5f;   

    private EnemyAI enemyAI;                              

    private void Awake()
    {
        // Установка уникальных параметров для BigSlime
        health = 4f;
        damage = 10f;
        attackRange = 4f; 
        attackCooldown = 3f;

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = 2f; // Уникальная скорость SmallSlime
        }
    }

    protected override void Die()
    {
        PlayerHealth.instance.RestoreHealth(20);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        // Спавним двух маленьких слизней после смерти
        if (smallSlimePrefab != null)
        {
            Vector3 spawnPosition1 = transform.position + new Vector3(-spawnOffset, 0f, 0f);
            Vector3 spawnPosition2 = transform.position + new Vector3(spawnOffset, 0f, 0f);

            Instantiate(smallSlimePrefab, spawnPosition1, Quaternion.identity);
            Instantiate(smallSlimePrefab, spawnPosition2, Quaternion.identity);
        }

        // Уничтожаем BigSlime
        Destroy(gameObject);
    }
}
