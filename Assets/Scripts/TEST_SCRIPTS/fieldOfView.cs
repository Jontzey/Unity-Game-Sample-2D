using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldOfView : MonoBehaviour
{

    
    public float radius;
    [Range(-360,360)]
    public float angle ;

    public GameObject playerRef;
    
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    [SerializeField]
    private float rotZ;
    private void Start(){

        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FovRoutine());
    }

    void Update(){
        if(canSeePlayer){
            Debug.Log("Sees Player");
        }else{
             Debug.Log("can't see Player");
        }
        // float rotationY = transform.eulerAngles.z % 360;
        // Debug.Log(rotationY);
    }
    private IEnumerator FovRoutine(){

        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while(true){
            yield return wait;
            fieldOfViewCheck();
        }
    }



    private void fieldOfViewCheck()
{
    Collider2D[] rangeChecks = Physics2D.OverlapCircleAll(transform.position, radius, targetMask);
         rotZ = checkObjectRotationZ();
    
    if (rangeChecks.Length != 0)
    {
        Transform target = rangeChecks[0].transform;
        Vector3 directionToTarget = (target.position - transform.position).normalized;

        // Check the character's facing direction using localScale.x
        if (transform.localScale.x > 0)
        {
            // Facing right
            Debug.Log("Looking to the right");
            test2(directionToTarget, target);
            // transform.localScale = new Vector3(-1, 1, 1); 
        }
        else if (transform.localScale.x < 0)
        {
            // Facing left
            Debug.Log("Looking to the left");
            test1(directionToTarget, target);
            // transform.localScale = new Vector3(1, 1, 1);
        }
        // Use transform.right for 2D directional checks
    //     if (Vector2.Angle(test, directionToTarget) < angle / 2)
    //     {
    //         float distanceToTarget = Vector3.Distance(transform.position, target.position);
            
    //         // Check for obstructions
    //         if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
    //         {
    //             canSeePlayer = true;

    //             // Uncomment to move toward the player
    //             // transform.position += directionToTarget * Time.deltaTime * 10;
    //         }
    //         else
    //         {
    //             canSeePlayer = false;
    //         }
    //     }
    //     else
    //     {
    //         canSeePlayer = false;
    //     }
    // }
    // else if (canSeePlayer)
    // {
    //     canSeePlayer = false;
    // }
    }
}
    float checkObjectRotationZ(){
        float rotationY = transform.eulerAngles.y % 360;
        return rotationY;
    }


   private void test1(Vector3 directionToTarget, Transform target){
        // Determine if the target is within the field of view
    if (Vector2.Angle(transform.right, directionToTarget) < angle / 2)
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Check for obstructions
        if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
        {
            canSeePlayer = true;

            // Uncomment to move toward the player
            transform.position += directionToTarget * Time.deltaTime * 3;
        }
        else
        {
            canSeePlayer = false;
        }
    }
    else
    {
        canSeePlayer = false;
    }
}


    
private void test2(Vector3 directionToTarget, Transform target){
        // Determine if the target is within the field of view
    if (Vector2.Angle(-transform.right, directionToTarget) < angle / 2)
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Check for obstructions
        if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
        {
            canSeePlayer = true;

            // Uncomment to move toward the player
            transform.position += directionToTarget * Time.deltaTime * 3;
        }
        else
        {
            canSeePlayer = false;
        }
    }
    else
    {
        canSeePlayer = false;
    }
}
private void OnDrawGizmosSelected()
{
   
      if (transform.localScale.x < 0)
        {        
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, radius);

            
            Vector3 angle01 = DirectionFromAngle(-angle / 2, true);
            Vector3 angle02 = DirectionFromAngle(angle / 2, true);

            
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + angle01 * radius);
            Gizmos.DrawLine(transform.position, transform.position + angle02 * radius);

            
            if (canSeePlayer && playerRef != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, playerRef.transform.position);
            }
        }
        else if (transform.localScale.x > 0)
        {
           
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, radius);

                //orginal
            // Vector3 angle01 = DirectionFromAngle(-angle / 2, false);
            // Vector3 angle02 = DirectionFromAngle(angle / 2, false);
            // Draw the field of view angles
            Vector3 angle01 = DirectionFromAngle(-angle / 2, false);
            Vector3 angle02 = DirectionFromAngle(angle / 2, false);

            Gizmos.color = Color.blue;

            Gizmos.DrawLine(transform.position, transform.position - angle01 * radius);
            Gizmos.DrawLine(transform.position, transform.position - angle02 * radius);

            //Original
            // Gizmos.DrawLine(transform.position, transform.position + angle01 * radius);
            // Gizmos.DrawLine(transform.position, transform.position + angle02 * radius);

            // If the player is in view, draw a line to the player
            if (canSeePlayer && playerRef != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, playerRef.transform.position);
            }
        }
}

// Calculate a direction vector from an angle (adjusted for 2D)
private Vector3 DirectionFromAngle(float angleInDegrees, bool isGlobal)
{
    if (!isGlobal)
    {
        angleInDegrees += transform.eulerAngles.z; // Adjust by local rotation in 2D
    }

    float rad = angleInDegrees * Mathf.Deg2Rad; // Convert to radians
    return new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0); // Calculate direction in 2D plane
}




























    // private void fieldOfViewCheck()
    // {
    //     Collider2D[] rangeChecks = Physics2D.OverlapCircleAll(transform.position, radius, targetMask);

    //     if(rangeChecks.Length != 0){
    //         Transform target = rangeChecks[0].transform;
    //         Vector3 directionToTarget = (target.position - transform.position).normalized;

    //         if(Vector2.Angle(transform.forward, directionToTarget) < angle / 2){
    //             float distanceoTarget = Vector3.Distance(transform.position, target.position);
    //             if(!Physics2D.Raycast(transform.forward, directionToTarget,distanceoTarget, obstructionMask)){
    //                 canSeePlayer = true;

    //                 // transform.position += directionToTarget * Time.deltaTime * 10;
    //             }else{
    //                 canSeePlayer = false;
    //             }
    //         }
    //         else{
    //             canSeePlayer = false;
    //         }
    //     }
    //     else if(canSeePlayer){
    //             canSeePlayer = false;
    //         }
    // }

    // private void OnDrawGizmosSelected()
    // {
    //     // Draw the field of view radius
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawWireSphere(transform.position, radius);

    //         //orginal
    //      Vector3 angle01 = DirectionFromAngle(-angle / 2, false);
    //     Vector3 angle02 = DirectionFromAngle(angle / 2, false);
    //     // Draw the field of view angles
    //     // Vector3 angle01 = DirectionFromAngle((-angle-180) / 2, false);
    //     // Vector3 angle02 = DirectionFromAngle((angle -180) / 2, false);

    //     Gizmos.color = Color.blue;

    //     Gizmos.DrawLine(transform.position, transform.position + angle01 * radius);
    //     Gizmos.DrawLine(transform.position, transform.position + angle02 * radius);

    //     //Original
    //     // Gizmos.DrawLine(transform.position, transform.position + angle01 * radius);
    //     // Gizmos.DrawLine(transform.position, transform.position + angle02 * radius);

    //     // If the player is in view, draw a line to the player
    //     if (canSeePlayer && playerRef != null)
    //     {
    //         Gizmos.color = Color.green;
    //         Gizmos.DrawLine(transform.position, playerRef.transform.position);
    //     }
    // }

    // // Calculate a direction vector from an angle
    // private Vector3 DirectionFromAngle(float eulerY, bool isGlobal)
    // {
    //     if (!isGlobal)
    //     {
    //         eulerY += transform.eulerAngles.z;
    //     }

    //     float rad = eulerY * Mathf.Deg2Rad;
    //     return new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0);
    // }
}
