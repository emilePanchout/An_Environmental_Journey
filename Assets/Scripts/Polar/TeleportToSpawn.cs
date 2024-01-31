using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToSpawn : MonoBehaviour
{
    public AudioSource disapearSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            disapearSound.Play();
            other.gameObject.transform.position = Vector3.zero;
        }

    }

}
