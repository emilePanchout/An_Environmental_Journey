using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class spawnFish : MonoBehaviour
{
    public List<GameObject> fishList;
    public GameObject sharkPrefab;
    public int minObjects;
    public int maxObjects;
    public int minHeight;
    public int maxHeight;
    public float spawnRadius = 10f;

    // Start is called before the first frame update
    void Start()
    {
        spawnFishRandom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnFishRandom()
    {
        int objectCount = Random.Range(minObjects, maxObjects + 1);

        for (int i = 0; i < objectCount; i++)
        {
            GameObject fishToSpawn = fishList[Random.Range(0, fishList.Count)];
            Vector3 randomPos = getRandomPos();
            GameObject thisFish = Instantiate(fishToSpawn, randomPos, Quaternion.identity);

            if (!thisFish.name.Equals("SharkV1(Clone)"))
            {
                thisFish.layer = LayerMask.NameToLayer("Eatable");
            }

        }
    }

    Vector3 getRandomPos()
    {
        //float angle = Random.Range(0f, 360f);
        //Vector3 randomDirection = Quaternion.Euler(0, angle, 0) * Vector3.forward;
        //float randomHeight = Random.Range(minHeight, maxHeight);

        //Vector3 randomPosition = transform.position + randomDirection * Random.Range(0f, spawnRadius);

        float randomX = Random.Range(-100, 100);
        float randomZ = Random.Range(-100, 100);
        float randomHeight = Random.Range(minHeight, maxHeight);

        Vector3 randomPos = new Vector3(randomX, randomHeight, randomZ);

        return randomPos;
    }
}
