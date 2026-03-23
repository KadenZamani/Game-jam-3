using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject player;

    public float spawnRadius = 10f;
    public int enemiesPerWave = 5;
    public float timeBetweenWaves = 5f;
    public float timeBetweenSpawns = 0.5f;

    public bool startOnAwake = true;

    private bool isSpawning = false;

    void Start()
    {
        if (startOnAwake)
        {
            Debug.Log("Spawner started");
            StartCoroutine(SpawnLoop());
        }
    }

    
    public void StartSpawning()
    {
        if (!isSpawning)
        {
            StartCoroutine(SpawnLoop());
        }
    }

    IEnumerator SpawnLoop()
    {
        isSpawning = true;

        while (true)
        {
            yield return StartCoroutine(SpawnWave());
            float adjustedTime = Mathf.Max(5f, timeBetweenWaves - (ScoreManager.Instance.GetScore() * 0.2f));
            Debug.Log("Score: " + ScoreManager.Instance.GetScore() + " | Next wave in: " + adjustedTime);
            yield return new WaitForSeconds(adjustedTime);
        }
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius; // random radius around spawner
        spawnPosition.y = transform.position.y; // keep on same plane

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        EnemyNavigation nav = enemy.GetComponent<EnemyNavigation>();
        if (nav != null)
        {
            nav.setPlayer(player);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
