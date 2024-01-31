using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHellicopter : MonoBehaviour
{
    public GameObject oldMamaBear;
    public GameObject newMamaBear;
    public GameObject bloc1;

    public GameObject boat;

    public bool driftingIsActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Jouer les sons bateaux plus crack

            driftingIsActive = true;
        }
            
    }


    public void Update()
    {
        if(driftingIsActive)
        {
            newMamaBear.transform.position = new Vector3(newMamaBear.transform.position.x, newMamaBear.transform.position.y, newMamaBear.transform.position.z + 0.25f);
            bloc1.transform.position = new Vector3(bloc1.transform.position.x + 0.25f, bloc1.transform.position.y, bloc1.transform.position.z + 0.25f);

            boat.SetActive(true);

            oldMamaBear.SetActive(false);
            newMamaBear.SetActive(true);
        }
        
    }
}
