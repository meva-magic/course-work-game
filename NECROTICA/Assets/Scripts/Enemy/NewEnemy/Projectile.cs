using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float damage = 10f; // Урон снаряда

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Снаряд столкнулся с объектом: {other.name}");
        if (other.CompareTag("Player")) // Проверяем, попал ли снаряд в игрока
        {
            Debug.Log("Снаряд попал в игрока!");
            AudioManager.instance.Play("SwordSwoosh");

            PlayerHealth.instance.TakeDamage((int)damage); // Наносим урон игроку
            Destroy(gameObject); // Уничтожаем снаряд
        }
        if (!other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}