using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PCManager : MonoBehaviour
{
    public Camera xr_camera;
    public Camera pc;
    public GameObject Spot;

    private void Start()
    {
        Spot.SetActive(false);
    }

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

    public void OnClick(InputAction.CallbackContext context)
    {
        Ray ray = pc.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.name == "Point")
            {
                Debug.Log(hit.collider.gameObject.name);
                Spot.SetActive(true);
                Spot.transform.parent = hit.collider.gameObject.transform.parent.transform;
                Spot.transform.position = new Vector3(hit.collider.gameObject.transform.parent.transform.position.x, 4, hit.collider.gameObject.transform.parent.transform.position.z);
            }
        }

    }
}
