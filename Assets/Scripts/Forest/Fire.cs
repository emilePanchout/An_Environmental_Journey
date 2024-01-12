using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fire : MonoBehaviour
{
    public List<GameObject> ensemble;
    private List<Transform> particules = new();
    public BlackFade blackfade;
    private float timeRemaining = 120;

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    FireStart = true;
        //    StartCoroutine(blackfade.StartChange());

        //    InvokeRepeating("Burning", 2f, 2f);  //1s delay, repeat every 1s
        //}

        if(blackfade.Fire == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                StartCoroutine(blackfade.FadeBlackOut());
                Transition.CrossTitle = "Feux de forêt dans le monde";
                Transition.CrossParagraphe = "Chaque année, c'est plus de 350 millions d'hectares, l'équivalent de 6 fois la superficie de la France, qui sont partis en fumée dans le monde entrainant avec eux la vie de beaucoup d'animaux. Rien qu'en Australie, en 2023, ce sont près de 3 milliards d'animaux morts brûlés ou asphyxiés par les flammes.\nL'activité humaine est à l'origine de 90% des incendies de forêt et le nombre de ceux-ci ne cessent d'augmenter.";
                Transition.CrossSources = "FAO, Greenly, WWF";
                Transition.CrossScene = "Forest";
                StartCoroutine(LoadYourAsyncScene());
            }
        }

    }

    public void StartFire()
    {
        StartCoroutine(blackfade.StartChange());

        InvokeRepeating("Burning", 2f, 2f);  //1s delay, repeat every 1s
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Transition");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private void Burning()
    {
        foreach (GameObject forest in ensemble)
        {
            int number = Random.Range(1, 7);

            GameObject set = forest.transform.Find("Set" + number).gameObject;

            foreach (Transform child in set.transform)
            {
                if (child.gameObject.activeSelf && child.tag == "Burn")
                {
                    StartCoroutine(Burned(child));
                }
                if (child.gameObject.name == "Particules" && !particules.Contains(child))
                {
                    child.GetComponent<ParticleSystem>().Play();
                    particules.Add(child);
                }
            }
        }
    }

    IEnumerator Burned(Transform child)
    {
        yield return new WaitForSeconds(5);
        child.gameObject.SetActive(false);

    }


}
