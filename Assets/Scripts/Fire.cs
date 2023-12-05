using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public List<GameObject> ensemble;
    private List<Transform> particules = new();

    public BlackFade blackfade;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(blackfade.StartChange());

            InvokeRepeating("Burning", 2f, 2f);  //1s delay, repeat every 1s
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
