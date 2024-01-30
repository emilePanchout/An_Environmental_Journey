using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnWater : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        AudioSource audioSource = other.GetComponent<AudioSource>();

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

}
