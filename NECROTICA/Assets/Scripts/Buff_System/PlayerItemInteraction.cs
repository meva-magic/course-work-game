using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemInteraction : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem particleEffect;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (animator == null)
        {
            return;
        }

        if (other.CompareTag("Baff"))
        {
            PlayPickUpAnimation("Kury");
            TriggerParticleEffect();
            Debug.Log("Attack animation triggered.");
        }
    }

    private void PlayPickUpAnimation(string animationTrigger)
    {
        if (animator != null)
        {
            animator.SetTrigger(animationTrigger);
        }
    }

    private void TriggerParticleEffect()
    {
        if (particleEffect != null)
        {
            particleEffect.Play();
        }
    }
}
