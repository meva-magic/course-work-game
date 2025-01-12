using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : BuffItem
{
    [SerializeField] GameObject pickUpEffect;
    [SerializeField] private float healthRestorePercent = 0.16f;
    [SerializeField] private float armorRestorePercent = 0.25f;
    [SerializeField] private float armorBuffDuration = 5.0f;

    protected override void ApplyBuff(PlayerMove playerMove, PlayerHealth playerHealth)
    {
        int healthRestore = Mathf.CeilToInt(playerHealth.maxHealth * healthRestorePercent);
        playerHealth.RestoreHealth(healthRestore);

        int armorRestore = Mathf.CeilToInt(playerHealth.maxArmor * armorRestorePercent);
        playerMove.StartCoroutine(ApplyArmorBuff(playerHealth, armorRestore));

        Debug.Log("Health restored by " + healthRestore + " and temporary armor to be restored by " + armorRestore);
    }

    private IEnumerator ApplyArmorBuff(PlayerHealth playerHealth, int armorAmount)
    {
        Instantiate(pickUpEffect, transform.position, Quaternion.identity);
        playerHealth.RestoreArmor(armorAmount);
        Debug.Log("Temporary armor applied: " + armorAmount);

        yield return new WaitForSeconds(armorBuffDuration);

        playerHealth.RestoreArmor(-armorAmount);
        Debug.Log("Temporary armor removed: " + armorAmount);
    }
}
