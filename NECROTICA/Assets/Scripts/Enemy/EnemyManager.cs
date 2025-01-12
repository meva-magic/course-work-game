using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<BaseEnemy> enemiesInTrigger = new List<BaseEnemy>();

    public static EnemyManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void AddEnemy(BaseEnemy enemy)
    {
        if (!enemiesInTrigger.Contains(enemy))
        {
            enemiesInTrigger.Add(enemy);
        }
    }

    public void RemoveEnemy(BaseEnemy enemy)
    {
        if (enemiesInTrigger.Contains(enemy))
        {
            enemiesInTrigger.Remove(enemy);
        }
    }
}
