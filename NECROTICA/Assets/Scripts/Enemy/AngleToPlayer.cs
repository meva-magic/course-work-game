using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleToPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 targetPosition;
    private Vector3 targetDirection;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;

    [SerializeField] private float angle;
    [SerializeField] private int lastIndex;


    private void Start()
    {
        player = FindFirstObjectByType<PlayerMove>().transform;
    }

    private void Update()
    {
        targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        targetDirection = targetPosition - transform.position;

        angle = Vector3.SignedAngle(targetDirection, transform.forward, Vector3.up);

        Vector3 tempScale = Vector3.one;
        if(angle > 0)
        {
            tempScale.x *= -1f;
        }

        spriteRenderer.transform.localScale = tempScale;

        lastIndex = GetIndex(angle);

        spriteRenderer.sprite = sprites[lastIndex];
    }

    private int GetIndex(float angle)
    {
        if(angle > -22.5f && angle < 22.6f)
        {return 0;}

        if(angle >= 22.5f && angle < 67.5f)
        {return 7;}

        if(angle >= 67.5f && angle < 112.5f)
        {return 6;}

        if(angle >= 112.5f && angle >=157.5f)
        {return 5;}



        if(angle >= -157.5f && angle >= 157.5f)
        {return 4;}

        if(angle >= -157.4f && angle < -112.5f)
        {return 3;}
        
        if(angle >= -112.5f && angle < -67.5f)
        {return 2;}

        if(angle >= -67.5f && angle <= -22.5f)
        {return 1;}

        return lastIndex;
    }

    void OnGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, targetPosition);
    }
}
