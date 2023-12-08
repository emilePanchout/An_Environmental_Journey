using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TextNav : MonoBehaviour
{
    public TextMeshProUGUI infoText;
    public TextMeshProUGUI instructionText;
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
        infoText.text = "Votre vie aquatique virtuelle s'est éteinte en rasion de la pollution plastique. " +
                "La réalité est tout aussi grave. Agissons ensemble pour préserver nos océans et protéger la diversité marine!";
    }
}
