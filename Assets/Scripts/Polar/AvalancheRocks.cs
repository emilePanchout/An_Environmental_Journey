using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvalancheRocks : MonoBehaviour
{
    public Transform respawnPoint;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            respawnPoint = GameObject.Find("AvalancheRespawn").transform;
            collision.gameObject.transform.position = respawnPoint.position;
        }
    }
}
