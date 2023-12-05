using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using UnityEngine.XR;

public class DeleteScript : MonoBehaviour
{
    public InputActionReference deleteRef;
    playerHealth pH;
    public TMP_Text healthText;
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

                if (playerHealth.currentHealth < 91)
                {
                    playerHealth.currentHealth += 10;
                    UpdateHealthText();
                }
                else
                {
                    playerHealth.currentHealth = 100;
                    UpdateHealthText();
                }

            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Trash"))
            {
                Destroy(hit.collider.gameObject);
                if (playerHealth.currentHealth > 10)
                {
                    playerHealth.currentHealth -= 10;
                    UpdateHealthText();
                }
                else
                {
                    playerHealth.currentHealth = 0;
                    UpdateHealthText();
                }

            }
        }
    }

    public void UpdateHealthText()
    {
        healthText.text = "Sant�: " + playerHealth.currentHealth;
        if (playerHealth.currentHealth == 0)
        {
            healthText.text = "Votre vie aquatique virtuelle s'est �teinte en rasion de la pollution plastique. " +
                "La r�alit� est tout aussi grave. Agissons ensemble pour pr�server nos oc�ans et prot�ger la diversit� marine!";
        }
    }

}
