using UnityEngine;

public class BossEnemy : BaseEnemy
{
    [SerializeField] private GameObject bigSlimePrefab; // Префаб BigSlime
    [SerializeField] private GameObject deathEffect;    // Эффект смерти
    [SerializeField] private float spawnOffset = 1.5f;

    private EnemyAI enemyAI;

    private void Awake()
    {
        health = 15f; // У босса много здоровья
        damage = 10f;  // Урон босса
        attackRange = 4f;
        attackCooldown = 4f;

        // Установить свойства NavMeshAgent
        var agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = 2f;
        }
    }



    protected override void Die()
    {
        PlayerHealth.instance.RestoreHealth(20);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        if (bigSlimePrefab != null)
            {
                Vector3 spawnPosition1 = transform.position + new Vector3(-spawnOffset, 0f, 0f);
                Vector3 spawnPosition2 = transform.position + new Vector3(spawnOffset, 0f, 0f);

                Instantiate(bigSlimePrefab, spawnPosition1, Quaternion.identity);
                Instantiate(bigSlimePrefab, spawnPosition2, Quaternion.identity);
            }
            Destroy(gameObject);
    }
}
