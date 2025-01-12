using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject Dialogue;
    public bool isTriggered;

    private Transform player;
    

    [SerializeField] private float talkRadius = 3;


    private void Start()
    {
        player = FindFirstObjectByType<PlayerMove>().transform;
    }

    private void Update()
    {
        var dist = Vector3.Distance(transform.position, player.position);

        if(dist < talkRadius)
        {
            isTriggered = true;
            Dialogue.SetActive(true);
        }
    }
}