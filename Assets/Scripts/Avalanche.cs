using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avalanche : MonoBehaviour
{

    public List<GameObject> avalanchePrefabs;
    public List<Transform> avalancheSpawners;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            int i = Random.Range(0, avalancheSpawners.Count -1);
            int j = Random.Range(0, 40);
            float k = Random.Range(0.5f, 6);
            if (j == 1)
            {
                var rock = Instantiate(avalanchePrefabs[0], avalancheSpawners[i]);
                rock.gameObject.transform.localScale = new Vector3(k, k, k);
                Destroy(rock, 10);
            }
            
        }
    }
}