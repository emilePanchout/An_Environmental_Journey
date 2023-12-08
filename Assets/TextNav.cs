using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TextNav : MonoBehaviour
{
    public TextMeshProUGUI infoText;
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
            UpdateText();
        }
    }

    void UpdateText()
    {
        infoText.text = texts[currentIndex];
    }

    void DisplayGameOverText()
    {
        infoText.text = "Votre vie aquatique virtuelle s'est éteinte en rasion de la pollution plastique. " +
                "La réalité est tout aussi grave. Agissons ensemble pour préserver nos océans et protéger la diversité marine!";
    }
}
