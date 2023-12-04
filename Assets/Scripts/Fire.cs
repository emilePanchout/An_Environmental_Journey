using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Burning", 1f, 1f);  //1s delay, repeat every 1s
    }

    private void Burning()
    {
        int number = Random.Range(1, 7);

        GameObject ensemble = gameObject.transform.Find("Ensemble1").gameObject;

        GameObject set = ensemble.transform.Find("Set" + number).gameObject;

        foreach (Transform child in set.transform)
        {
            if (child.gameObject.activeSelf && child.tag == "Burn")
            {
                StartCoroutine(Burned(child));
            }
            if(child.gameObject.name == "Particules")
            {
                child.GetComponent<ParticleSystem>().Play();
            }
        }
    }

    IEnumerator Burned(Transform child)
    {
        yield return new WaitForSeconds(5);
        child.gameObject.SetActive(false);

    }

}
