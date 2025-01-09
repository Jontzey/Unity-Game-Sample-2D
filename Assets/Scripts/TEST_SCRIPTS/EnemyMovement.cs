using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public LayerMask layer;
    public GameObject EnemyVisionObject;

    public bool FoundPlayer;

    [SerializeField]
    public float VisionX = 1;
    [SerializeField]
    public float VisionY = 1;

    private Vector3 lookLeft = new Vector3(0, 180, 0);
    private Vector3 lookRight = new Vector3(0, 0, 0);
    Vector2 test;

    private Vector3 startPosition;
    private Vector3 patrolLeft;
    private Vector3 patrolRight;
    public float patrolDistance = 2f;
    public float waitTime = 1f;
    public float patrolSpeed = 2f;

    private Coroutine patrolCoroutine;

    void Start()
    {
        // Initialize patrol points
        startPosition = transform.position;
        patrolLeft = startPosition - new Vector3(patrolDistance, 0, 0);
        patrolRight = startPosition + new Vector3(patrolDistance, 0, 0);

        // Start the patrol coroutine
        patrolCoroutine = StartCoroutine(testingPatrol());
    }

    void Update()
    {
        test = new Vector2(VisionX, VisionY);

        // Detect player within vision area
        Collider2D playerTarget = Physics2D.OverlapBox(EnemyVisionObject.transform.position, test, 0f, layer);

        if (playerTarget != null)
        {
            // Player found, start chasing
            FoundPlayer = true;
            StopPatrolling();
            ChasePlayer(playerTarget);
        }
        else
        {
            // Player not found, resume patrolling if not already patrolling
            if (FoundPlayer)
            {
                FoundPlayer = false;
                StartPatrolling();
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Draw vision box in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(EnemyVisionObject.transform.position, test);
    }

    private void ChasePlayer(Collider2D playerTarget)
    {
        Vector3 playerDistance = (transform.position - playerTarget.transform.position).normalized;
        Vector3 newPos = new Vector3(playerDistance.x, playerDistance.y, 0f);
        transform.position -= newPos * Time.deltaTime * 3;

        if (playerDistance.x < 0)
        {
            transform.eulerAngles = lookLeft;
        }
        if (playerDistance.x > 0)
        {
            transform.eulerAngles = lookRight;
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
        if (patrolCoroutine == null)
        {
            patrolCoroutine = StartCoroutine(testingPatrol());
        }
    }

    IEnumerator testingPatrol()
    {
        while (!FoundPlayer)
        {
            // Move to the right
            while (Vector3.Distance(transform.position, patrolRight) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, patrolRight, patrolSpeed * Time.deltaTime);
                transform.eulerAngles = lookLeft;
                yield return null; // Wait for the next frame
            }

            // Wait at the right point
            yield return new WaitForSeconds(waitTime);

            // Move to the left
            while (Vector3.Distance(transform.position, patrolLeft) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, patrolLeft, patrolSpeed * Time.deltaTime);
                transform.eulerAngles = lookRight;
                yield return null; // Wait for the next frame
            }

            // Wait at the left point
            yield return new WaitForSeconds(waitTime);
        }
    }
    
}
