using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class SmallSlime : BaseEnemy
{
    [SerializeField] private GameObject deathEffect;

    private void Awake()
    {
        // ”станавливаем уникальные параметры
        health = 2f;
        damage = 5f;
        attackRange = 4f;
        attackCooldown = 2f;

        // ”станавливаем скорость перемещени€
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = 3f; // ”никальна€ скорость SmallSlime
        }
    }

    public override void Attack()
    {
        base.Attack(); // ¬оспроизведение общего звука атаки из BaseEnemy

    }

    protected override void Die()
    {
        PlayerHealth.instance.RestoreHealth(10);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Debug.Log("SmallSlime уничтожен.");
        Destroy(gameObject);
    }
}
