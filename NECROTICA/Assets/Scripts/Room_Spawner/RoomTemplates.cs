using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] frontRooms;
    public GameObject[] backRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject[] bossFrontRooms;
    public GameObject[] bossBackRooms;
    public GameObject[] bossLeftRooms;
    public GameObject[] bossRightRooms;

    public GameObject[] keykeeperFrontRooms;
    public GameObject[] keykeeperBackRooms;
    public GameObject[] keykeeperLeftRooms;
    public GameObject[] keykeeperRightRooms;

    public GameObject closedRoom;
    public GameObject nextRoom;
    public List<GameObject> rooms;

    public float waitTime;
    public float replaceRoomTimer = 0f;
    public float replaceRoomDuration = 2f;

    private SpecialRoomSpawner specialRoomSpawner;

    public float specialRoomSpawnTimer = 8f;
    private bool specialRoomsSpawned = false;

    private void Start()
    {
        specialRoomSpawner = GetComponent<SpecialRoomSpawner>();
    }

    private void Update()
    {
        if (replaceRoomTimer > 0)
        {
            replaceRoomTimer -= Time.deltaTime;
            return;
        }

        if (waitTime <= 0)
        {
            if (rooms.Count < 14)
            {
                ReplaceLastRoomWithNextRoom();
            }
            else
            {
                HandleSpecialRoomSpawning();
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    private void ReplaceLastRoomWithNextRoom()
    {
        if (rooms.Count > 0)
        {
            GameObject currentLastRoom = rooms[rooms.Count - 1];
            if (currentLastRoom != null)
            {
                Vector3 lastRoomPosition = currentLastRoom.transform.position;
                Quaternion lastRoomRotation = currentLastRoom.transform.rotation;

                rooms.RemoveAt(rooms.Count - 1);
                Destroy(currentLastRoom);

                GameObject newRoom = Instantiate(nextRoom, lastRoomPosition, lastRoomRotation);
                rooms.Add(newRoom);
            }
        }

        replaceRoomTimer = replaceRoomDuration;
    }

    private void HandleSpecialRoomSpawning()
    {
        if (!specialRoomsSpawned)
        {
            specialRoomSpawnTimer -= Time.deltaTime;

            if (specialRoomSpawnTimer <= 0)
            {
                specialRoomSpawner.SpawnSpecialRooms(rooms);
                specialRoomsSpawned = true;
            }
        }
    }
}
