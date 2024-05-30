using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 10f;
    public float viewAngle = 45f;
    public LayerMask playerLayer;
    public LayerMask obstacleLayer;

    private bool isPlayerDetected;

    void Update()
    {
        DetectPlayer();
        if (isPlayerDetected && CanDestroyPlayer())
        {
            KillPlayer();
        }
    }

    void DetectPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

            if (angleToPlayer <= viewAngle / 2)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, directionToPlayer, out hit, detectionRadius, playerLayer | obstacleLayer))
                {
                    if (hit.collider.gameObject.CompareTag("Player"))
                    {
                        isPlayerDetected = true;
                        return;
                    }
                }
            }
        }
        isPlayerDetected = false;
    }

    bool CanDestroyPlayer()
    {
        return player.localScale.magnitude < transform.localScale.magnitude;
    }

    void KillPlayer()
    {
        Destroy(player.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Vector3 leftBoundary = Quaternion.Euler(0, -viewAngle / 2, 0) * transform.forward * detectionRadius;
        Vector3 rightBoundary = Quaternion.Euler(0, viewAngle / 2, 0) * transform.forward * detectionRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }
}
