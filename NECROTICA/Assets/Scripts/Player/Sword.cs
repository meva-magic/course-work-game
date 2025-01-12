using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private BoxCollider swordTrigger;
    public EnemyManager enemyManager;
    [SerializeField] private Animator animator;

    [SerializeField] private float range = 3f;
    [SerializeField] private float verticalRange = 3f;
    [SerializeField] public float damage = 2f;

    [SerializeField] private float hitRate = 1f;
    [SerializeField] private float nextTimeToHit;

    [SerializeField] private LayerMask raycastLayerMask;

    public int Score;

    public static Sword instance;

    private bool canAttack = true;
    public bool hasSword = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Score = 0;
        swordTrigger = GetComponent<BoxCollider>();
        swordTrigger.size = new Vector3(1.5f, verticalRange, range);
        swordTrigger.center = new Vector3(0, 0, range * 0.5f);
    }

    private void Update()
    {
        if (!hasSword)
            return;

        if (Input.GetMouseButtonDown(0) && canAttack && Time.time > nextTimeToHit)
        {
            if (animator != null)
            {
                canAttack = false;
                animator.SetTrigger("Attaka");
                AudioManager.instance.Play("SwordSwoosh");
                Debug.Log("Attack animation triggered.");
            }
            else
            {
                Debug.LogError("Animator is null. Cannot trigger animation.");
            }
        }
    }

    public void Hit()
    {
        List<BaseEnemy> enemiesToProcess = new List<BaseEnemy>(enemyManager.enemiesInTrigger);

        foreach (var enemy in enemiesToProcess)
        {
            if (enemy == null) continue;

            RaycastHit hit;
            var dir = enemy.transform.position - transform.position;

            if (Physics.Raycast(transform.position, dir, out hit, range * 1.5f, raycastLayerMask))
            {
                if (hit.transform == enemy.transform)
                {
                    enemy.TakeDamage(damage);
                    Score += 1;

                    FindObjectOfType<ScoreDisplayHandler>().UpdateScore(Score);
                }
            }
        }

        nextTimeToHit = Time.time + hitRate;
        canAttack = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        BaseEnemy enemy = other.transform.GetComponent<BaseEnemy>();
        if (enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        BaseEnemy enemy = other.transform.GetComponent<BaseEnemy>();
        if (enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }
}
