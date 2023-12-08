using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TextNav : MonoBehaviour
{
    public TextMeshProUGUI infoText;
    public TextMeshProUGUI instructionText;
    public AudioSource countdownSound;
    public string[] texts;
    private int currentIndex = 0;
    public InputActionReference changeRef;
    public InputActionReference restartRef;
    private bool allowTrigger = true;
    public static bool allowRestart = true;

    void Start()
    {
        allowRestart = true;
        DisplayGameOverText();
    }

    private void Update()
    {
        if (changeRef.action.triggered)
        {
            if (allowTrigger) {
                currentIndex = (currentIndex + 1) % texts.Length;
                UpdateTexts();
            }
            
        }

        if (restartRef.action.triggered)
        {
            if (allowRestart)
            {
                if ((SceneManager.GetActiveScene().name).Equals("End Scene"))
                {
                    StartCoroutine(Countdown());
                }
            }
        }
    }

    void UpdateTexts()
    {
        infoText.text = texts[currentIndex];

        if (currentIndex == 3)
        {
            instructionText.text = "";
        }
        else instructionText.text = "Press 'Trigger (right)'";
    }

    void DisplayGameOverText()
    {
        infoText.text = "Votre vie aquatique virtuelle s'est éteinte en raison de la pollution plastique. " +
                "La réalité est tout aussi grave. Agissons ensemble pour préserver nos océans et protéger la diversité marine!";
    }

    IEnumerator Countdown()
    {
        countdownSound.Play();
        instructionText.text = "";
        allowTrigger = false;
        allowRestart = false;

        for (int i = 3; i > 0; i--)
        {
            infoText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        playerHealth.currentHealth = 100;
        SceneManager.LoadScene("Ocean");
    }
}
