using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackFade : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject blackOutSquare;
    public GameObject FireOnGround;
    public GameObject BurnedGround;

    void Start()
    {
        FireOnGround.SetActive(false);
        BurnedGround.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(FadeBlackOut());
            StartCoroutine(ChangeScene());
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(FadeBlackOut(false));
        }
    }

    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1f);
        FireOnGround.SetActive(true);
        BurnedGround.SetActive(true);
        FireOnGround.GetComponent<ParticleSystem>().Play();
    }

    public IEnumerator FadeBlackOut(bool fadeToBlack = true, int fadeSpeed = 5)
    {
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        Debug.Log(fadeToBlack);

        if (fadeToBlack)
        {
            while(blackOutSquare.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        else
        {
            while (blackOutSquare.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }
}
