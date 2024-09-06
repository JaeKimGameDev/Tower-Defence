using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    // tuple of enemy waves and level of tuple to spawn
    public List<GameObject> enemyLevels = new List<GameObject>();
    public int currentEnemyLevel=0;

    public List<GameObject> enemies = new List<GameObject>();

    // where the enemy spawns
    public Transform spawnPoint;

    // timing for when enemies/waves spawn
    public float spawnTimeBetweenEnemies = 0.5f;
    public float timeBetweenWaves = 75f;
    public float countdown = 15f;

    // number of enemies that will spawn
    public int spawnNumOfEnemies = 30;

    // used to display on canvas/player the countdown for next wave
    public TextMeshProUGUI waveCountdownText;

    public Button forceSpawn;

    public bool waveCompleted = true;
    public bool levelCompleted = false;

    void Update()
    {
        if (countdown <= 0f && currentEnemyLevel < enemyLevels.Count)
        {
            forceSpawnWave();
        }
        else if (waveCompleted == true)
        {
            countdown -= Time.deltaTime;
            waveCountdownText.text = "Next Wave: " + countdown.ToString("0");
        }
        //if (currentEnemyLevel >= enemyLevels.Count)
        //{
        //    levelCompleted = true;
        //    Debug.Log("level is done");
        //}
    }

    IEnumerator SpawnWave()
    {
        for (int i=0; i<spawnNumOfEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnTimeBetweenEnemies);
        }
        forceSpawn.interactable = true;
        waveCompleted = true;
        countdown = timeBetweenWaves;
        currentEnemyLevel++;
    }

    void SpawnEnemy()
    {
        enemies.Add(Instantiate(enemyLevels[currentEnemyLevel], spawnPoint.position, spawnPoint.rotation));
    }

    public void forceSpawnWave()
    {
        if (currentEnemyLevel < enemyLevels.Count)
        {
            forceSpawn.interactable = false;
            waveCompleted = false;
            countdown = timeBetweenWaves;
            StartCoroutine(SpawnWave());
        }
    }
}
