using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // Start is called before the first frame update
    public Coroutine patrolCoroutine;
    private Vector3 lookLeft = new Vector3(0, 180, 0);
    private Vector3 lookRight = new Vector3(0, 0, 0);
    public Vector3 patrolLeft;
    public Vector3 patrolRight;

    EnemyAI enemyAI;
    EnemyFovScript enemyFovScript;

    Animator anim;
    void Start()
    {

        anim = GetComponent<Animator>();

        enemyAI = GetComponent<EnemyAI>();
        enemyFovScript = GetComponent<EnemyFovScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void StartPatrolling()
    {
        patrolLeft = transform.position - Vector3.right * enemyAI.patrolDistance;
        patrolRight = transform.position + Vector3.right * enemyAI.patrolDistance;
        patrolCoroutine = StartCoroutine(Patrol());
    }


    public void StopPatrolling()
    {
        if (patrolCoroutine != null)
        {
            StopCoroutine(patrolCoroutine);
            patrolCoroutine = null;
        }
    }



    private IEnumerator Patrol()
    {
        while (!enemyAI.canSeePlayer)
        {
            // Move to the right
            while (Vector3.Distance(transform.position, patrolRight) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, patrolRight, enemyAI.patrolSpeed * Time.deltaTime);
                transform.localScale = new Vector3(-1, 1, 1); // Facing right
                yield return null;
            }

            // Wait at the right point
            yield return new WaitForSeconds(enemyAI.waitTime);

            // Move to the left
            while (Vector3.Distance(transform.position, patrolLeft) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, patrolLeft, enemyAI.patrolSpeed * Time.deltaTime);
                transform.localScale = new Vector3(1, 1, 1); // Facing left
                yield return null;
            }

            // Wait at the left point
            yield return new WaitForSeconds(enemyAI.waitTime);
        }
    }


    // public void ChasePlayer(Transform playerTarget)
    // {
    //     enemyFovScript.CheckAttackRange();
    //     Vector3 directionToPlayer = (playerTarget.position - transform.position).normalized;
    //          transform.position += directionToPlayer * Time.deltaTime * enemyAI.enemySpeed;
    //     if(enemyAI.isInAttackRange == false){
    //     }else if(enemyAI.isInAttackRange == true){
    //         anim.SetBool("2_Attack", true);
    //         Debug.Log("In attack range");
    //     }else{
    //         enemyAI.isInAttackRange = false;
    //     }

    //     // Flip character based on player's position
    //     if (directionToPlayer.x > 0)
    //     {
    //         transform.localScale = new Vector3(-1, 1, 1); // Facing right
    //     }
    //     else
    //     {
    //         transform.localScale = new Vector3(1, 1, 1); // Facing left
    //     }
    // }


}
