using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialRoomSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    public float spawnTimeout = 12f;

    private bool bossSpawned = false;

    public void SpawnSpecialRooms(List<GameObject> rooms)
    {
        if (rooms.Count < 14) return;

        if (!bossSpawned && rooms.Count >= 14)
        {
            GameObject lastRoom = rooms[rooms.Count - 1];
            if (lastRoom != null)
            {
                SpawnBoss(lastRoom);
                bossSpawned = true;
            }
        }
        StartCoroutine(CheckAndAssignBossRoom(rooms));
    }

    private void SpawnBoss(GameObject targetRoom)
    {
        Vector3 bossSpawnPosition = targetRoom.transform.position + Vector3.up * 2;
        Instantiate(bossPrefab, bossSpawnPosition, Quaternion.identity);
    }

    private IEnumerator CheckAndAssignBossRoom(List<GameObject> rooms)
    {
        yield return new WaitForSeconds(spawnTimeout);

        if (!bossSpawned && rooms.Count > 0)
        {
            Debug.LogWarning("Spawn timeout reached. Assigning the last room as the boss room.");
            GameObject lastRoom = rooms[rooms.Count - 1];
            if (lastRoom != null)
            {
                SpawnBoss(lastRoom);
                bossSpawned = true;
            }
        }
    }
}
