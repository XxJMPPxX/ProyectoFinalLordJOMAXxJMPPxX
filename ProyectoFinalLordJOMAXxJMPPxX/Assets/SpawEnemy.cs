using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del monstruo a spawnear
    public Transform[] spawnPoints; // Puntos de aparición posibles
    public float spawnInterval = 3f; // Intervalo de tiempo entre apariciones

    private int maxEnemies = 20; // Máximo de monstruos a spawnear
    private int currentEnemies = 0; // Contador de monstruos actuales
    private float spawnTimer = 0f; // Temporizador para controlar el intervalo de aparición

    void Update()
    {
        if (currentEnemies < maxEnemies)
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnInterval)
            {
                SpawnEnemigos();
                spawnTimer = 0f;
            }
        }
    }

    void SpawnEnemigos()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
        currentEnemies++;
    }
}
