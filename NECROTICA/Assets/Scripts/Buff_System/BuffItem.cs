using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffItem : MonoBehaviour
{
    protected abstract void ApplyBuff(PlayerMove playerMove, PlayerHealth playerHealth);

    private void OnTriggerEnter(Collider other)
    {
        PlayerMove playerMove = other.GetComponent<PlayerMove>();
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerMove != null && playerHealth != null)
        {
            ApplyBuff(playerMove, playerHealth);
            AudioManager.instance.Play("BuffPickUp");
            Effect.instance.ScreenShake();
            Destroy(gameObject);
        }
    }
}