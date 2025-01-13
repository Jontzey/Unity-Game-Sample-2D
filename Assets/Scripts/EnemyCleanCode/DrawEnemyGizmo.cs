// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class DrawEnemyGizmo : MonoBehaviour
// {
//     // Start is called before the first frame update
//     private GameObject playerRef;
//     public EnemyAI enemyBehaviorScript;

//     private void Start()
//     {
//         enemyBehaviorScript = GetComponent<EnemyAI>();

//         if(!enemyBehaviorScript){
//             Debug.Log("didnt find the script");
//         }else{
//             Debug.Log("found the script");
//         }
//         // Assign playerRef in Start
//         playerRef = GameObject.FindGameObjectWithTag("Player");
//     }

//      private void OnDrawGizmos()
//     {
//         Gizmos.color = Color.yellow;
//         Gizmos.DrawWireSphere(transform.position, enemyBehaviorScript.radius);

//         Vector3 angle01 = DirectionFromAngle(-enemyBehaviorScript.angle / 2, false);
//         Vector3 angle02 = DirectionFromAngle(enemyBehaviorScript.angle / 2, false);

//         Gizmos.DrawWireSphere(transform.position,  enemyBehaviorScript.attackRadius);
//         if (transform.localScale.x < 0) // Facing right
//         {
//             Gizmos.color = Color.blue;
//             Gizmos.DrawLine(transform.position, transform.position + angle01 * enemyBehaviorScript.radius);
//             Gizmos.DrawLine(transform.position, transform.position + angle02 * enemyBehaviorScript.radius);
//         }
//         else // Facing left
//         {
//             Gizmos.color = Color.blue;
//             Gizmos.DrawLine(transform.position, transform.position - angle01 * enemyBehaviorScript.radius);
//             Gizmos.DrawLine(transform.position, transform.position - angle02 * enemyBehaviorScript.radius);
//         }

//         if (enemyBehaviorScript.canSeePlayer && playerRef != null)
//         {
//             Gizmos.color = Color.green;
//             Gizmos.DrawLine(transform.position, playerRef.transform.position);
//         }
//     }

    

//      private Vector3 DirectionFromAngle(float angleInDegrees, bool isGlobal)
//     {
//         if (!isGlobal)
//         {
//             angleInDegrees += transform.eulerAngles.z;
//         }

//         float rad = angleInDegrees * Mathf.Deg2Rad;
//         return new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0);
//     }
// }
