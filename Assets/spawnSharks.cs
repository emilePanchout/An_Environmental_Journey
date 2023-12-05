using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class spawnSharks : MonoBehaviour
{
    public GameObject sharkModel;
    public int minSharks;
    public int maxSharks;
    public int minHeight;
    public int maxHeight;
    public float spawnRadius = 10f;
    public float minSpeed = 1f;
    public float maxSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        spawnSharksRandom();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnSharksRandom()
    {
        int objectCount = Random.Range(minSharks, maxSharks + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPos = getRandomPos();

            GameObject thisShark = Instantiate(sharkModel, randomPos, Quaternion.identity);
            Vector3 randomDirection = Random.insideUnitSphere;
            float randomSpeed = Random.Range(minSpeed, maxSpeed);

            FishMoves fishMoves = thisShark.AddComponent<FishMoves>();
            fishMoves.setMovementParameters(randomDirection, randomSpeed);
            thisShark.layer = LayerMask.NameToLayer("Sharks");
            thisShark.tag = "Shark";

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
