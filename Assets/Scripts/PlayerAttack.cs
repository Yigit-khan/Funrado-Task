using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRadius = 5f;
    public float attackAngle = 45f;
    public LayerMask enemyLayer;

    void Update()
    {
        DetectAndAttackEnemies();
    }

    void DetectAndAttackEnemies()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRadius, enemyLayer);

        foreach (Collider collider in hitColliders)
        {
            GameObject enemy = collider.gameObject;

            Vector3 playerPos = transform.position;
            Vector3 enemyPos = enemy.transform.position;

            Vector3 playerForward = transform.forward;

            Vector3 toEnemy = enemyPos - playerPos;

            playerForward.y = 0;
            toEnemy.y = 0;

            float angle = Vector3.Angle(playerForward, toEnemy);

            if (angle <= attackAngle / 2 && toEnemy.magnitude <= attackRadius)
            {
                Vector3 enemyScale = enemy.transform.localScale;
                Vector3 playerScale = transform.localScale;

                if (enemyScale.magnitude <= playerScale.magnitude)
                {
                    Destroy(enemy);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRadius);

        Vector3 frontLeft = Quaternion.Euler(0, -attackAngle / 2, 0) * transform.forward * attackRadius;
        Vector3 frontRight = Quaternion.Euler(0, attackAngle / 2, 0) * transform.forward * attackRadius;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + frontLeft);
        Gizmos.DrawLine(transform.position, transform.position + frontRight);
        Gizmos.DrawLine(transform.position + frontLeft, transform.position + frontRight);
    }
}
