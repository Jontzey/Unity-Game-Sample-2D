// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemyFovScript : MonoBehaviour
// {
//     // Start is called before the first frame update

//     EnemyAI enemyAiScript;
//     void Start()
//     {
//         enemyAiScript = GetComponent<EnemyAI>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//     public IEnumerator FovRoutine()
//     {
//         WaitForSeconds wait = new WaitForSeconds(1f);
//         while (true)
//         {
//             yield return wait;
//             FieldOfViewCheck();
//         }
//     }
//      private void FieldOfViewCheck()
//     {
//         Collider2D[] rangeChecks = Physics2D.OverlapCircleAll(transform.position, enemyAiScript.radius, enemyAiScript.targetMask);

//         if (rangeChecks.Length > 0)
//         {
//             enemyAiScript.target = rangeChecks[0].transform;
//             Vector3 directionToTarget = (enemyAiScript.target.position - transform.position).normalized;

//             // Check field of view
//             if (IsTargetInFieldOfView(directionToTarget))
//             {
//                 float distanceToTarget = Vector3.Distance(transform.position, enemyAiScript.target.position);

//                 // Check for obstructions
//                 if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, enemyAiScript.obstructionMask))
//                 {
//                     enemyAiScript.canSeePlayer = true;
//                     return;
//                 }
//             }
//         }

//         enemyAiScript.canSeePlayer = false;
//         enemyAiScript.target = null;
//     }


//     private bool IsTargetInFieldOfView(Vector3 directionToTarget)
//     {
//         if (transform.localScale.x > 0) // Facing right
//         {
//             return Vector2.Angle(-transform.right, directionToTarget) < enemyAiScript.angle / 2;
//         }
//         else // Facing left
//         {
//             return Vector2.Angle(transform.right, directionToTarget) < enemyAiScript.angle / 2;
//         }
//     }


//      public void CheckAttackRange(){

//           Collider2D[] attackRangeChecks = Physics2D.OverlapCircleAll(transform.position, enemyAiScript.attackRadius, enemyAiScript.targetMask);

//         if (attackRangeChecks.Length > 0)
//         {
//             enemyAiScript.target = attackRangeChecks[0].transform;
//             Vector3 directionToTarget = (enemyAiScript.target.position - transform.position).normalized;

//             if (IsTargetInFieldOfView(directionToTarget))
//             {
//                 float distanceToTarget = Vector3.Distance(transform.position, enemyAiScript.target.position);

//                 if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, enemyAiScript.obstructionMask))
//                 {
//                     enemyAiScript.canSeePlayer = true;
//                     enemyAiScript.isInAttackRange = true;
//                     return;
//                 }else{
//                     enemyAiScript.isInAttackRange = false;
//                 }
//             }
//         }

//         enemyAiScript.isInAttackRange = false;
//     }
// }
