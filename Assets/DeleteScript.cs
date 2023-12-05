using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using UnityEngine.XR;

public class DeleteScript : MonoBehaviour
{
    public InputActionReference deleteRef;
    public TMP_Text healthText;
    private int health = 100;
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
                if (health < 91)
                {
                    health += 10;
                    UpdateHealthText();
                }
                else
                {
                    health = 100;
                    UpdateHealthText();
                }

            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Trash"))
            {
                Destroy(hit.collider.gameObject);
                if (health > 10)
                {
                    health -= 10;
                    UpdateHealthText();
                }
                else
                {
                    health = 0;
                    UpdateHealthText();
                }

            }
        }
    }

    void UpdateHealthText()
    {
        healthText.text = "Sant�: " + health;
        if (health == 0)
        {
            healthText.text = "Votre vie aquatique virtuelle s'est �teinte en rasion de la pollution plastique. " +
                "La r�alit� est tout aussi grave. Agissons ensemble pour pr�server nos oc�ans et prot�ger la diversit� marine!";
            //gameOver();
            // doesn't work --- XRDevice.DisableAutoXRCameraTracking(Camera.main, true);
        }
    }

   /* void gameOver()
    {

    } */
}
