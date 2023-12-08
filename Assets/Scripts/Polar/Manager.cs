using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public InputActionReference mapInput;
    public GameObject mapCanvas;

    void Start()
    {
        mapInput.action.performed += ShowMap;
    }

    public void ShowMap(InputAction.CallbackContext act)
    {
        if(mapCanvas.activeSelf)
        {
            mapCanvas.SetActive(false);
        }
        else
        {
            mapCanvas.SetActive(true);
        }
    }
}
