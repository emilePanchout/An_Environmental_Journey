using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToSpawn : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = Vector3.zero;
        }

    }

}
