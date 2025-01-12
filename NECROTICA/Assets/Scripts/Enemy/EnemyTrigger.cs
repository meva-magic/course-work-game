using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float awarenessRadius = 7f;

    public bool isTriggered;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerMove>().transform;
    }

    private void Update()
    {
        var dist = Vector3.Distance(transform.position, player.position);
        isTriggered = dist < awarenessRadius;
    }
}
