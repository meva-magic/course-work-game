using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class AddRoom : MonoBehaviour
{
    private RoomTemplates templates;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.rooms.Add(this.gameObject);
    }
}
