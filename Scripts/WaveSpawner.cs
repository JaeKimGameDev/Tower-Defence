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
    [SerializeField] private float timeBetweenWaves = 25f;
    private float countdown = 15f;
    [SerializeField]
    private int spawnNumOfEnemies = 30;

    public TextMeshProUGUI waveCountdownText;
    public Button forceSpawn;
    public TextMeshProUGUI forceSpawnText;

    [SerializeField] private PlayerAttributes playerAttributes;

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
        // waves ended, reward player
        forceSpawn.interactable = true;
        forceSpawnText.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
        countdown = timeBetweenWaves;
        waveLevel++;
        int rand1 = Random.Range(0, 20);
        int resourceUp = 1;
        if (rand1 <= 16)
        {
            resourceUp = 1;
        }
        else if (rand1 <= 18)
        {
            resourceUp = 2;
        }
        else
        {
            resourceUp = 3;
        }
        playerAttributes.GetComponent<PlayerAttributes>().IncrementPlayerResource(resourceUp);
    }
    void SpawnEnemy()
    {
        enemies.Add(Instantiate(enemyWaves[waveLevel], spawnPoint.position, spawnPoint.rotation));
    }
}
