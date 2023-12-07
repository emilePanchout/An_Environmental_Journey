using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class spawnTrashOnEnter : MonoBehaviour
{
    public List<GameObject> trashList;
    public int objectCount;
    public int minHeight;
    public int maxHeight;
    public int trashSpawnCount;
    public float spawnRadius = 10f;

    // Start is called before the first frame update
    void Start()
    {
        spawnTrashRandom();
        spawnTrashRandom();
        spawnTrashRandom();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (trashSpawnCount > 0)
            {
                spawnTrashRandom();
                trashSpawnCount--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            killFishRandom();
            killSharkRandom();
        }
    }

    void spawnTrashRandom()
    {
        for (int i = 0; i < 50; i++)
        {
            GameObject trashToSpawn = trashList[Random.Range(0, trashList.Count)];
            Vector3 randomPos = getRandomPos();

            GameObject thisTrash= Instantiate(trashToSpawn, randomPos, Quaternion.identity);

            thisTrash.layer = LayerMask.NameToLayer("Trash");

        }
    }

    void killFishRandom()
    {
        GameObject[] fishInScene = GameObject.FindGameObjectsWithTag("Fish");

        for (int i = 0; i < 50; i++)
        {
            if (fishInScene.Length > 0)
            {
                int randomFishIndex = Random.Range(0, fishInScene.Length);
                Destroy(fishInScene[randomFishIndex]);
            }
        }
        
    }

    void killSharkRandom()
    {
        GameObject[] sharkInScene = GameObject.FindGameObjectsWithTag("Shark");

        if (sharkInScene.Length > 0)
        {
            int randomFishIndex = Random.Range(0, sharkInScene.Length);
            Destroy(sharkInScene[randomFishIndex]);
        }

    }

    Vector3 getRandomPos()
    {
        float randomX = Random.Range(-100, 100);
        float randomZ = Random.Range(-100, 100);
        float randomHeight = Random.Range(minHeight, maxHeight);

        Vector3 randomPos = new Vector3(randomX, randomHeight, randomZ);

        return randomPos;
    }
}
