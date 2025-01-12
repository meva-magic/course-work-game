using UnityEngine;

public class SwordPickUp : MonoBehaviour
{
    public GameObject Dialogue;
    [SerializeField] private GameObject pickUpEffect;
    [SerializeField] private GameObject playerSwordObject;
    [SerializeField] private Transform player;
    [SerializeField] private float pickUpRange = 2.0f;

    private bool isPickedUp = false;

    private void Start()
    {
        if (playerSwordObject != null)
        {
            playerSwordObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (isPickedUp)
            return;

        if (player == null)
        {
            Debug.LogError("Player Transform не назначен!");
            return;
        }

        Vector3 distanceToPlayer = player.position - transform.position;

        if (distanceToPlayer.magnitude <= pickUpRange && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        if (isPickedUp)
            return;

        isPickedUp = true;

        if (playerSwordObject != null)
        {
            playerSwordObject.SetActive(true);

            Sword swordScript = playerSwordObject.GetComponent<Sword>();
            if (swordScript != null)
            {
                swordScript.enabled = true;
                swordScript.hasSword = true; // Разрешаем атаку
            }
        }

        if (pickUpEffect != null)
        {
            Instantiate(pickUpEffect, transform.position, Quaternion.identity);
        }

        AudioManager.instance.Play("SwordSwoosh");
        UIManager.instance.GetSword();
        gameObject.SetActive(false);
        Dialogue.SetActive(true);
    }
}