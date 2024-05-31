using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float amplitude = 1.0f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
