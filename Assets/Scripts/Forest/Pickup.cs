using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Pickup : MonoBehaviour
{
    public InputActionReference pickup;

    public TMP_Text animalSaved;

    public AudioSource picksound;

    public GameObject tutorial;

    private int i = 1;

    //private void Update()
    //{
    //    RaycastHit hit;

    //    if (Physics.Raycast(transform.position, transform.forward, out hit))
    //    {
    //        if (hit.collider.tag == "Animal")
    //        {
    //            Debug.Log("hit animal");
    //            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
    //            if (pickup.action.triggered)
    //            {
    //                Pick(hit);
    //            }

    //        }
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Animal")
        {
            Debug.Log(other.gameObject.name);
            //other.gameObject.GetComponent<Highlight>()?.ToggleHighlight(true);
            other.gameObject.GetComponent<Outline>().enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Animal")
        {
            if (pickup.action.triggered)
            {
                Pick(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Animal")
        {
            //other.gameObject.GetComponent<Highlight>()?.ToggleHighlight(true);
            other.gameObject.GetComponent<Outline>().enabled = false;

        }
    }
    //public void Pick(RaycastHit hit)
    //{
    //    hit.collider.gameObject.SetActive(false);
    //    animalSaved.text = "Saved : " + i;
    //    i++;
    //    picksound.Play();
    //}

    public void Pick(GameObject animal)
    {
        animal.SetActive(false);
        if (!tutorial.activeSelf)
        {
            animalSaved.text = "Saved : " + i;
            i++;
        }
        picksound.Play();
    }


}
