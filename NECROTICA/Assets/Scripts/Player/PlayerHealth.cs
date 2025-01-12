using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;

    private float decreaseHealthAmount = 1f;

    [SerializeField] public float maxArmor = 100f;
    [SerializeField] private float armor;

    public bool playerIsDead;
    public static PlayerHealth instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        health = maxHealth;
        //health = Mathf.CeilToInt(maxHealth * 0.5f);
        armor = 0;
    }

    private void Update()
    {
        if(health <= 0)
        {
            playerIsDead = true;
            UIManager.instance.GameOver();
            AudioManager.instance.Play("PlayerDeath");
        }
        
        health -= decreaseHealthAmount * Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        AudioManager.instance.Play("PlayerHit");

        if(armor > 0)
        {
            if(armor >= damage)
            {
                armor -= damage;
            }

            else if(armor < damage)
            {
                float remainingDamage = damage - armor;
                armor = 0;

                health -= remainingDamage;
            }
        }

        else
        {
            health -= damage;
        }
    }
    
    public void RestoreHealth(int amount)
    {
        health = Mathf.Min(health + amount, maxHealth);
        //health = Mathf.Lerp(health, newhealth, 0.03f);
    }

    public void RestoreArmor(int amount)
    {
        armor = Mathf.Min(armor + amount, maxArmor);
    }
}
