using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvalancheRocks : MonoBehaviour
{
    [SerializeField]
    private AudioClip _hurt;
    [SerializeField]
    private AudioClip _fall;

    public Transform respawnPoint;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            respawnPoint = GameObject.Find("AvalancheRespawn").transform;
            collision.gameObject.transform.position = respawnPoint.position;
            AudioSource.PlayClipAtPoint(_hurt, respawnPoint.position);
        }

        else if(!collision.gameObject.CompareTag("Water"))
        {
            AudioSource.PlayClipAtPoint(_fall, transform.position);
        }
    }
}
