using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewAndPatrol : MonoBehaviour
{
    // Patrol variables
    private Vector3 lookLeft = new Vector3(0, 180, 0);
    private Vector3 lookRight = new Vector3(0, 0, 0);
    private Vector3 patrolLeft;
    private Vector3 patrolRight;
    public float patrolDistance = 2f;
    public float waitTime = 1f;
    public float patrolSpeed = 2f;

    private Coroutine patrolCoroutine;

    // Field of View variables
    public float radius;
    [Range(0, 360)] public float angle;

    public GameObject playerRef;
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    private Transform target;
    private bool canSeePlayer;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        patrolLeft = transform.position - Vector3.right * patrolDistance;
        patrolRight = transform.position + Vector3.right * patrolDistance;
        StartCoroutine(FovRoutine());
        StartPatrolling();
    }

    private void Update()
    {
        if (canSeePlayer && target != null)
        {
            StopPatrolling();
            ChasePlayer(target);
        }
        else if (!canSeePlayer)
        {
            if (patrolCoroutine == null)
            {
                StartPatrolling();
            }
        }
    }

    private void ChasePlayer(Transform playerTarget)
    {
        Vector3 directionToPlayer = (playerTarget.position - transform.position).normalized;
        transform.position += directionToPlayer * Time.deltaTime * 3;

        // Flip character based on player's position
        if (directionToPlayer.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Facing right
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1); // Facing left
        }
    }

    private void StopPatrolling()
    {
        if (patrolCoroutine != null)
        {
            StopCoroutine(patrolCoroutine);
            patrolCoroutine = null;
        }
    }

    private void StartPatrolling()
    {
        patrolCoroutine = StartCoroutine(Patrol());
    }

    private IEnumerator Patrol()
    {
        while (!canSeePlayer)
        {
            // Move to the right
            while (Vector3.Distance(transform.position, patrolRight) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, patrolRight, patrolSpeed * Time.deltaTime);
                transform.localScale = new Vector3(-1, 1, 1); // Facing right
                yield return null;
            }

            // Wait at the right point
            yield return new WaitForSeconds(waitTime);

            // Move to the left
            while (Vector3.Distance(transform.position, patrolLeft) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, patrolLeft, patrolSpeed * Time.deltaTime);
                transform.localScale = new Vector3(1, 1, 1); // Facing left
                yield return null;
            }

            // Wait at the left point
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator FovRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider2D[] rangeChecks = Physics2D.OverlapCircleAll(transform.position, radius, targetMask);

        if (rangeChecks.Length > 0)
        {
            target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            // Check field of view
            if (IsTargetInFieldOfView(directionToTarget))
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                // Check for obstructions
                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    return;
                }
            }
        }

        canSeePlayer = false;
        target = null;
    }

    private bool IsTargetInFieldOfView(Vector3 directionToTarget)
    {
        if (transform.localScale.x > 0) // Facing right
        {
            return Vector2.Angle(-transform.right, directionToTarget) < angle / 2;
        }
        else // Facing left
        {
            return Vector2.Angle(transform.right, directionToTarget) < angle / 2;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);

        Vector3 angle01 = DirectionFromAngle(-angle / 2, false);
        Vector3 angle02 = DirectionFromAngle(angle / 2, false);

        if (transform.localScale.x < 0) // Facing right
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + angle01 * radius);
            Gizmos.DrawLine(transform.position, transform.position + angle02 * radius);
        }
        else // Facing left
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position - angle01 * radius);
            Gizmos.DrawLine(transform.position, transform.position - angle02 * radius);
        }

        if (canSeePlayer && playerRef != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, playerRef.transform.position);
        }
    }

    private Vector3 DirectionFromAngle(float angleInDegrees, bool isGlobal)
    {
        if (!isGlobal)
        {
            angleInDegrees += transform.eulerAngles.z;
        }

        float rad = angleInDegrees * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0);
    }
}
