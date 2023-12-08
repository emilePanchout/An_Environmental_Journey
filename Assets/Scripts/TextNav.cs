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

    void Start()
    {
        DisplayGameOverText();
    }

    private void Update()
    {
        if (changeRef.action.triggered)
        {
            currentIndex = (currentIndex + 1) % texts.Length;
            UpdateTexts();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Countdown());
        }
    }

    void UpdateTexts()
    {
        infoText.text = texts[currentIndex];

        if (currentIndex == 3)
        {
            instructionText.text = "";
        }
        else instructionText.text = "Press 'Trigger (left)'";
    }

    void DisplayGameOverText()
    {
        infoText.text = "Votre vie aquatique virtuelle s'est �teinte en rasion de la pollution plastique. " +
                "La r�alit� est tout aussi grave. Agissons ensemble pour pr�server nos oc�ans et prot�ger la diversit� marine!";
    }

    IEnumerator Countdown()
    {
        countdownSound.Play();

        for (int i = 3; i > 0; i--)
        {
            infoText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        SceneManager.LoadScene("Ocean");
    }
}