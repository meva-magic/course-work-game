using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private enum EnemyState
    {
        Idle,
        Chasing,
        Attacking
    }

    [SerializeField] private float awarenessRadius = 10f;
    private EnemyState currentState = EnemyState.Idle;

    private Transform player;
    private NavMeshAgent agent;
    private BaseEnemy baseEnemy;

    private float attackCooldownTimer = 0f;

    private void Start()
    {
        player = Object.FindFirstObjectByType<PlayerMove>().transform;
        agent = GetComponent<NavMeshAgent>();
        baseEnemy = GetComponent<BaseEnemy>();
    }

    private void Update()
    {
        HandleState();
        UpdateCooldown();
    }

    private void HandleState()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        switch (currentState)
        {
            case EnemyState.Idle:
                if (distanceToPlayer <= awarenessRadius)
                {

                    ChangeState(EnemyState.Chasing);
                }
                break;

            case EnemyState.Chasing:
                if (distanceToPlayer > awarenessRadius)
                {
                    ChangeState(EnemyState.Idle);
                }
                else if (distanceToPlayer <= baseEnemy.attackRange)
                {
                    ChangeState(EnemyState.Attacking);
                }
                else
                {
                    ChasePlayer();
                }
                break;

            case EnemyState.Attacking:
                Debug.Log("Attacking player...");
                agent.isStopped = true;
                if (distanceToPlayer > baseEnemy.attackRange)
                {
                    agent.isStopped = false;
                    ChangeState(EnemyState.Chasing);
                }
                else if (attackCooldownTimer <= 0f)
                {
                    baseEnemy.Attack();
                    attackCooldownTimer = baseEnemy.attackCooldown;
                }
                break;
        }
    }

    private void ChasePlayer()
    {
        if (!agent.isStopped)
        {
            Debug.Log("Chasing player...");
            agent.SetDestination(player.position);
        }
    }

    private void UpdateCooldown()
    {
        if (attackCooldownTimer > 0f)
        {
            attackCooldownTimer -= Time.deltaTime;
        }
    }

    private void ChangeState(EnemyState newState)
    {
        Debug.Log($"Changing state from {currentState} to {newState}");
        currentState = newState;
    }
}
