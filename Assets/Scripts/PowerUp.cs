using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float growthFactor = 1.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Transform playerTransform = other.transform;

            playerTransform.localScale *= growthFactor;

            Destroy(gameObject);
        }
    }
}
