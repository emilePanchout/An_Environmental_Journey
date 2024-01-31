using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public InputActionReference mapInput;
    public GameObject mapCanvas;


    public InputActionReference tpInput;
    public Transform skipPos;


    public InputActionReference resetInput;
    public Transform resetPos;

    public GameObject player;
    void Start()
    {
        mapInput.action.performed += ShowMap;
        tpInput.action.performed += TeleportSkip;
        resetInput.action.performed += TeleportReset;
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

    public void TeleportSkip(InputAction.CallbackContext act)
    {
        player.transform.position = skipPos.position;
    }

    public void TeleportReset(InputAction.CallbackContext act)
    {
        player.transform.position = resetPos.position;
    }
}
