using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    [Header("Base Stats")]
    public float health = 10f;         // Здоровье
    public float damage = 5f;          // Урон
    public float attackRange = 2f;     // Радиус атаки
    public float attackCooldown = 3f; // Кулдаун атаки

    public virtual void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        Debug.Log($"{gameObject.name} получил урон, осталось {health} HP.");

        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Attack()

    {
        Debug.Log($"{gameObject.name} атакует игрока и наносит {damage} урона!");
        PlayerHealth.instance.TakeDamage((int)damage);
    }

    protected abstract void Die(); // Логика смерти для уникальных врагов
}
