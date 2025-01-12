using UnityEngine;

using UnityEngine.UI;

public class ArmorBar : MonoBehaviour
{
    public Slider armorSlider;
    public Slider SliderDelay;

    private float lerpSpeed = 0.03f;

    private void Start()
    {
        armorSlider.value = 1;
        SliderDelay.value = 1;
    }

    private void Update()
    {
        if(armorSlider.value != PlayerHealth.instance.health / 100)
        {
            armorSlider.value = PlayerHealth.instance.health / 100;
        }

        if(armorSlider.value != SliderDelay.value)
        {
            SliderDelay.value = Mathf.Lerp(SliderDelay.value,  (PlayerHealth.instance.health / 100), lerpSpeed);
        }
    }
}
