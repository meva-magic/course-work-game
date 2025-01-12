using UnityEngine;
using System.Collections.Generic;

public class Spawn : MonoBehaviour
{
    public static Spawn Instance;

    public GameObject[] Eye;
    public GameObject[] Slime;
    public GameObject[] SmallSlime;

    public GameObject[] Flower;
    public GameObject[] Mushroom;

    public List<Transform> EyeSpawnPoints;
    public List<Transform> SlimeSpawnPoints;
    public List<Transform> SmallSlimeSpawnPoints;

    public List<Transform> FlowerSpawnPoints;
    public List<Transform> MushroomSpawnPoints;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SpawnAll();
    }

    public void SpawnAll()
    {
        foreach (Transform spawnPoint in EyeSpawnPoints)
        {
            int rand = Random.Range(0, Eye.Length);
            Instantiate(Eye[rand], spawnPoint.position, Quaternion.identity);
        }

        foreach (Transform spawnPoint in SlimeSpawnPoints)
        {
            int rand = Random.Range(0, Slime.Length);
            Instantiate(Slime[rand], spawnPoint.position, Quaternion.identity);
        }

        foreach (Transform spawnPoint in SmallSlimeSpawnPoints)
        {
            int rand = Random.Range(0, SmallSlime.Length);
            Instantiate(SmallSlime[rand], spawnPoint.position, Quaternion.identity);
        }

        foreach (Transform spawnPoint in FlowerSpawnPoints)
        {
            int rand = Random.Range(0, Flower.Length);
            Instantiate(Flower[rand], spawnPoint.position, Quaternion.identity);
        }

        foreach (Transform spawnPoint in MushroomSpawnPoints)
        {
            int rand = Random.Range(0, Mushroom.Length);
            Instantiate(Mushroom[rand], spawnPoint.position, Quaternion.identity);
        }
    }
}
