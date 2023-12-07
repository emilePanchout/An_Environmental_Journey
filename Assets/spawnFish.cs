using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class spawnFish : MonoBehaviour
{
    public List<GameObject> fishList;
    public int minObjects;
    public int maxObjects;
    public int minHeight;
    public int maxHeight;
    public float spawnRadius = 10f;
    public float minSpeed = 1f;
    public float maxSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        spawnFishRandom();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spawnFishRandomOnClick();
            Debug.Log("Click 1");
        }
    }

    void spawnFishRandom()
    {
        int objectCount = Random.Range(minObjects, maxObjects + 1);

        for (int i = 0; i < objectCount; i++)
        {
            GameObject fishToSpawn = fishList[Random.Range(0, fishList.Count)];
            Vector3 randomPos = getRandomPos();

            GameObject thisFish = Instantiate(fishToSpawn, randomPos, Quaternion.identity);

            Vector3 randomDirection = Random.insideUnitSphere;

            float randomSpeed = Random.Range(minSpeed, maxSpeed);

            FishMoves fishMoves = thisFish.AddComponent<FishMoves>();
            fishMoves.setMovementParameters(randomDirection, randomSpeed);

            thisFish.layer = LayerMask.NameToLayer("Eatable");
            thisFish.tag = "Fish";

        }
    }

    void spawnFishRandomOnClick()
    {
        int objectCount = 25;

        for (int i = 0; i < objectCount; i++)
        {
            GameObject fishToSpawn = fishList[Random.Range(0, fishList.Count)];
            Vector3 randomPos = getRandomPos();

            GameObject thisFish = Instantiate(fishToSpawn, randomPos, Quaternion.identity);

            Vector3 randomDirection = Random.insideUnitSphere;

            float randomSpeed = Random.Range(minSpeed, maxSpeed);

            FishMoves fishMoves = thisFish.AddComponent<FishMoves>();
            fishMoves.setMovementParameters(randomDirection, randomSpeed);

            thisFish.layer = LayerMask.NameToLayer("Eatable");
            thisFish.tag = "Fish";

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
