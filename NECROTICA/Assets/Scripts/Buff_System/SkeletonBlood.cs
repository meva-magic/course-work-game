using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBlood : BuffItem
{
    [SerializeField] GameObject pickUpEffect;
    [SerializeField] private float speedIncrease = 5f;
    [SerializeField] private float buffDuration = 10f;

    protected override void ApplyBuff(PlayerMove playerMove, PlayerHealth playerHealth)
    {
        playerMove.StartCoroutine(ApplySpeedBuff(playerMove));
    }

    private IEnumerator ApplySpeedBuff(PlayerMove playerMove)
    {
        Instantiate(pickUpEffect, transform.position, Quaternion.identity);
        playerMove.playerSpeed += speedIncrease;
        Debug.Log("Speed increased by " + speedIncrease + " for " + buffDuration + " seconds.");

        yield return new WaitForSeconds(buffDuration);

        playerMove.playerSpeed -= speedIncrease;
        Debug.Log("Speed buff ended. Speed decreased by " + speedIncrease);
    }
}

