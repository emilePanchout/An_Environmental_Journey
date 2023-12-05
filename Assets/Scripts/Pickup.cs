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

    private int i = 1;

    private void Update()
    {
        if (pickup.action.triggered)
        {
            Pick();
        }
    }

    public void Pick()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.tag == "Animal")
            {
                hit.collider.gameObject.SetActive(false);
                animalSaved.text = "Saved : " + i;
                i++;
                picksound.Play();
            }
        }
    }


}
