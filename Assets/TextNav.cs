using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextNav : MonoBehaviour
{
    public TextMeshProUGUI infoText;
    public string[] texts;
    private int currentIndex = 0;

    public void ShowNextText()
    {
        currentIndex = (currentIndex + 1) % texts.Length;
        UpdateText();
    }
    public void ShowPreviousText()
    {
        currentIndex = (currentIndex - 1 + texts.Length) % texts.Length;
        UpdateText();
    }

    private void UpdateText()
    {
        if (currentIndex >= 0 && currentIndex < texts.Length)
        {
            infoText.text = texts[currentIndex];
        }
    }
}
