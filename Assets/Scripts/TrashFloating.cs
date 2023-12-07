using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashFloating : MonoBehaviour
{

    public float floatAmplitude = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yOffset = floatAmplitude * Mathf.Sin(Time.time);
        transform.Translate(Vector3.up * yOffset * Time.deltaTime);
        
    }
}
