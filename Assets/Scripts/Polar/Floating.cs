using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public float amplitude = 0.5f; 
    public float speed = 1.0f;
    private Transform baseTransform;

    public void Start()
    {
        baseTransform = transform;
    }

    void Update()
    {
        float verticalMovement = Mathf.PingPong(Time.time * speed, amplitude * 2f) - amplitude;
        transform.position = new Vector3(transform.position.x, baseTransform.position.y + verticalMovement, transform.position.z);
    }
}
