using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float timeBetweenWaves = 5.5f;
    public Text waveCountdownText;

    private int waveIndex = 0;
    private float countdown = 2f;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        waveIndex++; 

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);        
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, PathGenerator.spawnPoint, Quaternion.identity);
    }
}
