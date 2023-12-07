using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleActivation : MonoBehaviour
{
    public ParticleSystem particle;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ParticleCollider"))
        {
            particle.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ParticleCollider"))
        {
            particle.Stop();
        }
    }
}
