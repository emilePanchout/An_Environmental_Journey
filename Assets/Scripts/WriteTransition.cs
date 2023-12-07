using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WriteTransition : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI paragraphe;
    public TextMeshProUGUI sources;
    private string scene;

    void Start()
    {
        title.text = Transition.CrossTitle;
        paragraphe.text = Transition.CrossParagraphe;
        sources.text = Transition.CrossSources;
        scene = Transition.CrossScene;
    }

    public void ChangeScene()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
