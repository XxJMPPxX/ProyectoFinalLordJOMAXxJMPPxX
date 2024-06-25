using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints; 
    public float spawnInterval = 3f; 

    private int maxEnemies = 20; 
    private int currentEnemies = 0; 

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (currentEnemies < maxEnemies)
        {
            yield return new WaitForSeconds(spawnInterval);

            int spawnIndex = Random.Range(0, spawnPoints.Length); 
            int enemyIndex = Random.Range(0, enemyPrefabs.Length); 

            Instantiate(enemyPrefabs[enemyIndex], spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            currentEnemies++;
        }
    }
}
