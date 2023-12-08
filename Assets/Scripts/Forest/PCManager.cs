using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PCManager : MonoBehaviour
{
    public Camera xr_camera;
    public void ChangeCamera(InputAction.CallbackContext context)
    {
        if (xr_camera.depth == -1)
        {
            xr_camera.depth = 1;
        }
        else
        {
            xr_camera.depth = -1;
        }
    }
}
