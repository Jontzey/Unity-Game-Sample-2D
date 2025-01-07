using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float patrolDistance = 2f;
    public float waitTime = 1f;
    public float patrolSpeed = 2f;
    public float enemySpeed = 2f;
    // private Coroutine patrolCoroutine;

    // Field of View variables
    [SerializeField]
    public float radius = 3;
    [SerializeField]
    public float attackRadius = 1.5f;
    [Range(0, 360)] 
    [SerializeField]
    public float angle = 100;
    [SerializeField] private float attackDelay = 0.2f;
    public GameObject playerRef;
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public Transform target;
    public bool canSeePlayer;
    public bool isInAttackRange;

    EnemyFovScript enemyFovScript;
    EnemyPatrol enemyPatrol;

    Animator anim;
    private void Start()
    {
        enemyFovScript = GetComponent<EnemyFovScript>();
        enemyPatrol = GetComponent<EnemyPatrol>();
        playerRef = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();

        
        
        StartCoroutine(enemyFovScript.FovRoutine());
        enemyPatrol.StartPatrolling();
    }

    private void Update()
    {
    
        if (canSeePlayer && target != null)
        {
            enemyPatrol.StopPatrolling();
            ChasePlayer(target);
        }
        else if (!canSeePlayer)
        {
            if (enemyPatrol.patrolCoroutine == null)
            {
                enemyPatrol.StartPatrolling();
            }
        }
    }

 private bool isAttacking = false;

public void ChasePlayer(Transform playerTarget)
{
    enemyFovScript.CheckAttackRange();

    if (isInAttackRange)
    {
        // Trigger attack animation only if not already attacking
        if (!isAttacking)
        {
            Debug.Log("In attack range, attacking...");
            StartCoroutine(AttackPlayer());
        }
    }
    else
    {
        // Move towards the player
        Vector3 directionToPlayer = (playerTarget.position - transform.position).normalized;
        transform.position += directionToPlayer * Time.deltaTime * enemySpeed;

        // Flip character based on player's position
        transform.localScale = directionToPlayer.x > 0
            ? new Vector3(-1, 1, 1) // Facing right
            : new Vector3(1, 1, 1);  // Facing left
    }
}

IEnumerator AttackPlayer()
{
    isAttacking = true; // Set the flag to prevent re-entry
    anim.SetBool("2_Attack", true);

    yield return new WaitForSeconds(attackDelay);

    anim.SetBool("2_Attack", false); // Reset animation state if needed
    isAttacking = false; // Allow attacking again
}
}
