using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider damegeSliderDelay;
    public Slider healSliderDelay;
    private float lerpSpeed = 0.03f;
    public static PlayerHealthBar instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        healthSlider.value = 1;
        damegeSliderDelay.value = 1;
    }

    private void Update()
    {
        if(healthSlider.value != PlayerHealth.instance.health / 100)
        {
            healthSlider.value = PlayerHealth.instance.health / 100;
        }

        if(healthSlider.value != damegeSliderDelay.value)
        {
            damegeSliderDelay.value = Mathf.Lerp(damegeSliderDelay.value,  (PlayerHealth.instance.health / 100), lerpSpeed);
        }
    }

    public void HealBarIncrease()
    {
        //healSliderDelay.value = (PlayerHealth.instance.health / 100) + 0.16f;
        healSliderDelay.value = Mathf.Lerp(healSliderDelay.value,  (PlayerHealth.instance.health / 100) + 0.16f, lerpSpeed);
        //healSliderDelay.value = 0;
    }
}
