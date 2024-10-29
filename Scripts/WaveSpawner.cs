using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [Header("Enemies Info")]
    public List<GameObject> enemyWaves = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();
    public int waveLevel=0;
    public Transform spawnPoint;
    [SerializeField] private float timeBetweenEnemies = 2.5f;
    private float timeBetweenWaves = 75f;
    private float countdown = 15f;
    [SerializeField]
    private int spawnNumOfEnemies = 30;
    private WaveSpawner waveSpawner;

    public TextMeshProUGUI waveCountdownText;
    public Button forceSpawn;
    public TextMeshProUGUI forceSpawnText;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartWave();
            countdown = timeBetweenWaves;
        }
        else if (enemies.Count == 0)
        {
            countdown -= Time.deltaTime;
            waveCountdownText.text = "Next Wave: " + countdown.ToString("0");
        }
    }

    public void StartWave()
    {
        forceSpawn.interactable = false;
        forceSpawnText.GetComponent<TextMeshProUGUI>().color = new Color32(50, 50, 50, 255);
        countdown = timeBetweenWaves;
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        for (int i=0; i<spawnNumOfEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
        forceSpawn.interactable = true;
        forceSpawnText.GetComponent<TextMeshProUGUI>().color = new Color32(0, 0, 0, 255);
        countdown = timeBetweenWaves;
        waveLevel++;
    }

    void SpawnEnemy()
    {
        enemies.Add(Instantiate(enemyWaves[waveLevel], spawnPoint.position, spawnPoint.rotation));
    }
}
