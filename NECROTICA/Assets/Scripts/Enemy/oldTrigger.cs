using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger0 : MonoBehaviour
{
    [SerializeField] private Material agroMat;
    public bool isTriggered;


    private void Update()
    {
        if(isTriggered)
        {
            GetComponent<MeshRenderer>().material = agroMat;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            isTriggered = true;
        }
    }
}
