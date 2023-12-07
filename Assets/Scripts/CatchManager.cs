using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class CatchManager : MonoBehaviour
{
    public bool playerHasBear = false;

    public Collider handCollider;
    public GameObject leftHand;

    public InputActionReference select;
    public GameObject bearSlot;


    // Update is called once per frame
    void Start()
    {
        select.action.performed += Catch;
        select.action.canceled += endCatch;
    }

    public void Catch(InputAction.CallbackContext act)
    {
        handCollider.enabled = true;
    }
    public void endCatch(InputAction.CallbackContext act)
    {
        handCollider.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bear"))
        {
            other.transform.SetParent(bearSlot.transform, false);
            playerHasBear = true;
            leftHand.SetActive(false);
        }
    }

}
