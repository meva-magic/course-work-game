using UnityEngine;

public class YellowKeyPickup : MonoBehaviour
{
    public GameObject Dialogue;
    public float activationDistance = 2f; // ��������� ���������
    private GameObject player;
    private PickupManager pickupManager;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        pickupManager = Object.FindFirstObjectByType<PickupManager>();

        if (pickupManager == null)
        {
            Debug.LogError("PickupManager �� ������ � �����!");
        }
    }

    void Update()
    {
        if (player == null || pickupManager == null) return;

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= activationDistance && Input.GetKeyDown(KeyCode.Space))
        {
            ActivatePickup();
        }
    }

    void ActivatePickup()
    {
        Debug.Log("YellowKey ������!");
        pickupManager.yellowKeyPickedUp = true;
        Dialogue.SetActive(true);
        Destroy(gameObject);
    }
}
