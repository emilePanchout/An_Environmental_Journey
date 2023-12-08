using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public bool fadeIn = false;
    public bool fadeOut = false;
    public bool fadeText = false;
    public CanvasGroup UI;
    public GameObject texts;

    private void Start()
    {
        UI.alpha = 1f;
        StartCoroutine(Wait());
        texts.SetActive(false);

    }

    public void Update()
    {

        if(fadeOut)
        {
            UI.alpha -= Time.deltaTime;
            if (UI.alpha == 0)
            {
                fadeOut = false;
            }
        }

        if(fadeIn)
        {
            UI.alpha += Time.deltaTime;
            if (UI.alpha == 1)
            {
                fadeIn = false;
            }
        }

    }

    public void ShowBlinder()
    {
        fadeIn = true;
    }
    public void HideBlinder()
    {
        fadeOut = true;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        texts.SetActive(true);
        yield return new WaitForSeconds(4);
        fadeOut = true;
    }
}
