using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class DeleteScript : MonoBehaviour
{
    public InputActionReference deleteRef;
    //private AudioManager audioManager;

    private void Start()
    {
    }

    private void Update()
    {
        if (deleteRef.action.triggered)
        {
            onDelete();
        }
    }

    private void onDelete()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Eatable"))
            {
                Destroy(hit.collider.gameObject);

                // updateHealth

            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Trash"))
            {
                Destroy(hit.collider.gameObject);
                // updateHealth

            }
        }
    }

}
