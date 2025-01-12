using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteLook : MonoBehaviour
{
    private Transform target;
    [SerializeField] private bool canLookVertically;


    private void Start()
    {
        target = FindFirstObjectByType<PlayerMove>().transform;
    }

    private void Update()
    {
        if(canLookVertically)
        {
            transform.LookAt(target);
        }

        else
        {
            Vector3 modifiedTarget = target.position;
            modifiedTarget.y = target.position.y;
            transform.LookAt(modifiedTarget);
        }
    }
}
