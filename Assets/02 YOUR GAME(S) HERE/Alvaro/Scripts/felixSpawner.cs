using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class felixSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;

    public float screenWidth = 10f;
    public float screenHeight = 5f;

    void SpawnRandomObject()
    {
        float x = Random.Range(-screenWidth / 2f, screenWidth / 2f);
        float y = Random.Range(-screenHeight / 2f, screenHeight / 2f);

        GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

        Instantiate(objectToSpawn, new Vector3(x, y, 0f), Quaternion.identity);
    }

    void Start()
    {
        foreach (var objectToSpawn in objectsToSpawn)
        {
            
            float x = Random.Range(-screenWidth / 2f, screenWidth / 2f);
            float y = Random.Range(-screenHeight / 2f, screenHeight / 2f);
            Instantiate(objectToSpawn, new Vector3(x, y, 0f), Quaternion.identity);
        }
    }
}
