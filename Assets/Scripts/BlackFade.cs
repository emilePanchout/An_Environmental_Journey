using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackFade : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject FireOnGround;
    public GameObject BurnedGround;
    public GameObject Fog;
    public GameObject Light;

    public Material blackOutSquare;

    void Start()
    {
        FireOnGround.SetActive(false);
        BurnedGround.SetActive(false);
        Fog.SetActive(false);
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
        Fog.SetActive(true);
        Light.SetActive(false);

        FireOnGround.GetComponent<ParticleSystem>().Play();
        Fog.GetComponent<ParticleSystem>().Play();

        RenderSettings.skybox = null;
        //RenderSettings.skybox.SetColor("_Tint", Color.black);
        RenderSettings.skybox = blackOutSquare;
    }

    public IEnumerator FadeBlackOut(bool fadeToBlack = true, int fadeSpeed = 5)
    {
        Color objectColor = blackOutSquare.color;
        float fadeAmount;

        Debug.Log(fadeToBlack);

        if (fadeToBlack)
        {
            while(blackOutSquare.color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.color = objectColor;
                yield return null;
            }
        }
        else
        {
            while (blackOutSquare.color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.color = objectColor;
                yield return null;
            }
        }
    }
}
