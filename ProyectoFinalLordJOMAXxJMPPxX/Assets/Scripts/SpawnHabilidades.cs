using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHabilidades : MonoBehaviour
{
    public GameObject objectPrefab1; 
    public GameObject objectPrefab2; 
    public float spawnInterval = 3f; 
    public int maxObjects = 10; 
   
    private int currentObjectCount = 0; 

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }


    private IEnumerator SpawnObjects()
    {
        while (currentObjectCount < maxObjects)
        {
            Vector3 randomSpawnPosition1 = new Vector3(Random.Range(-87.7f, 88.1f), 0.9f, Random.Range(-80.9f, 80.9f));
            Instantiate(objectPrefab1, randomSpawnPosition1, Quaternion.identity);
            currentObjectCount++;

            if (currentObjectCount >= maxObjects) break;

            Vector3 randomSpawnPosition2 = new Vector3(Random.Range(-87.7f, 88.1f), 0.9f, Random.Range(-80.9f, 80.9f));
            Instantiate(objectPrefab2, randomSpawnPosition2, Quaternion.identity);
            currentObjectCount++;

            if (currentObjectCount >= maxObjects) break;

            yield return new WaitForSeconds(spawnInterval);
            
        }
    }
}
