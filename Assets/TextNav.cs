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
        infoText.text = "Votre vie aquatique virtuelle s'est �teinte en rasion de la pollution plastique. " +
                "La r�alit� est tout aussi grave. Agissons ensemble pour pr�server nos oc�ans et prot�ger la diversit� marine!";
    }
}
