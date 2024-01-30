using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHellicopter : MonoBehaviour
{
    public GameObject MamaBearBloc;
    public GameObject boat;

    public bool driftingIsActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Jouer les sons bateaux plus crack

            boat.SetActive(true);

            driftingIsActive = true;
        }
            
    }

    public void Update()
    {
        if(driftingIsActive)
        {
            MamaBearBloc.transform.position = new Vector3(MamaBearBloc.transform.position.x, MamaBearBloc.transform.position.y, MamaBearBloc.transform.position.z + 0.25f);
        }
        
    }
}
