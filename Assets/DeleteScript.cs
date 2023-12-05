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
        healthText.text = "Santé: " + health;
        if (health == 0)
        {
            healthText.text = "Votre vie aquatique virtuelle s'est éteinte en rasion de la pollution plastique. " +
                "La réalité est tout aussi grave. Agissons ensemble pour préserver nos océans et protéger la diversité marine!";
            //gameOver();
            // doesn't work --- XRDevice.DisableAutoXRCameraTracking(Camera.main, true);
        }
    }

   /* void gameOver()
    {

    } */
}
