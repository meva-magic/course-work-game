using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Effect : MonoBehaviour
{
    //public GameObject ParticleEffect;  
      
    public GameObject centerPoint;

    public SpriteRenderer rend;
    
    public GameObject bloodStain;
    public GameObject healStain;

    public Animator CamAnim;

    public static Effect instance;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        centerPoint = GameObject.FindGameObjectWithTag("CenterPoint");
    }


    public void ScreenShake()
    {
        CamAnim.SetTrigger("Shake");
    }
    

    public void DamageFlash()
    {
        GameObject newBloodStain = Instantiate(bloodStain, centerPoint.transform.position, transform.rotation) as GameObject;
        rend = newBloodStain.GetComponent<SpriteRenderer>();

        StartCoroutine(Fade());
        Destroy(newBloodStain, 2f);
    }

    public void HealFlash()
    {
        GameObject newHealStain = Instantiate(healStain, centerPoint.transform.position, transform.rotation) as GameObject;
        rend = newHealStain.GetComponent<SpriteRenderer>();

        StartCoroutine(Fade());
        Destroy(newHealStain, 2f);
    }


    IEnumerator Fade()
    {
        float alphaVal = rend.color.a;
        Color tmp = rend.color;

        while (rend.color.a < 1)
        {
            alphaVal -= 0.01f;
            tmp.a = alphaVal;
            rend.color = tmp;

            yield return new WaitForSeconds(0.06f);
        }
    }
}
