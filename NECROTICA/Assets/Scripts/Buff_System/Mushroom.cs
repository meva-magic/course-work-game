using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : BuffItem
{
    [SerializeField] GameObject pickUpEffect;
    [SerializeField] private float damageIncrease = 5f;
    [SerializeField] private float buffDuration = 10f;

    protected override void ApplyBuff(PlayerMove playerMove, PlayerHealth playerHealth)
    {
        int healthToLose = Mathf.CeilToInt(playerHealth.health * 0.25f);
        playerHealth.TakeDamage(healthToLose);
        Debug.Log("Health reduced by " + healthToLose + " due to Mushroom effect.");

        Sword sword = playerMove.GetComponentInChildren<Sword>();

        if (sword != null)
        {
            playerMove.StartCoroutine(ApplyDamageBuff(sword)); 
        }
    }

    private IEnumerator ApplyDamageBuff(Sword sword)
    {
        Instantiate(pickUpEffect, transform.position, Quaternion.identity);
        sword.damage += damageIncrease;
        Debug.Log("Damage increased by " + damageIncrease + " for " + buffDuration + " seconds.");

        yield return new WaitForSeconds(buffDuration);

        sword.damage -= damageIncrease;
        Debug.Log("Damage buff ended. Damage decreased by " + damageIncrease);
    }
}

