using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHellicopter : MonoBehaviour
{
    public GameObject oldMamaBear;
    public GameObject newMamaBear;
    public GameObject bloc1;

    public GameObject boat;
    public GameObject fadeSphere;
    public Renderer renderer;
    private Color lerpedColor;

    public bool driftingIsActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MamaBearCollider"))
        {
            Console.WriteLine(other.name);
            // Jouer les sons bateaux plus crack
            boat.GetComponent<AudioSource>().Play();
            bloc1.GetComponent<AudioSource>().Play();

            driftingIsActive = true;
            StartCoroutine(Countdown(5));
        }
            
  
            
    }


    public void Update()
    {
        if(driftingIsActive)
        {
            newMamaBear.transform.position = new Vector3(newMamaBear.transform.position.x, newMamaBear.transform.position.y, newMamaBear.transform.position.z + 0.25f);
            bloc1.transform.position = new Vector3(bloc1.transform.position.x + 0.25f, bloc1.transform.position.y, bloc1.transform.position.z + 0.25f);

            boat.SetActive(true);

            oldMamaBear.SetActive(false);
            newMamaBear.SetActive(true);
        }
        
    }


    void Fade()
    {
        fadeSphere.SetActive(true);
        lerpedColor = Color.Lerp(Color.clear, Color.black, Mathf.PingPong(Time.time, 5));
        renderer.material.color = lerpedColor;
    }

    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        Fade();
    }
}
