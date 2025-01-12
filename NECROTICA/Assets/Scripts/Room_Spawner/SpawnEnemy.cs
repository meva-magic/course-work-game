using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; // Префаб врага

    private void OnEnable()
    {
        // Спауним врага сразу при активации точки
        EnemySpawn();
    }

    private void EnemySpawn()
    {
        if (enemyPrefab != null)
        {
            // Спауним врага на месте точки спауна
            Instantiate(enemyPrefab, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogWarning("Enemy prefab is not assigned in SpawnPoint!");
        }

        // Уничтожаем объект точки спауна
        Destroy(gameObject);
    }
}
