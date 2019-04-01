using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Enemy drone;
    public Enemy attackDrone;
    private Transform dronePrefab;
    private Transform attackDronePrefab;

    public Transform spawnPoint;
    public Transform endPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text waveCountdownText;

    public static int waveIndex = 0;

    private void Awake()
    {
        dronePrefab = drone.gameObject.transform;
        attackDronePrefab = attackDrone.gameObject.transform;
    }

    void Update()
    {
        if(countdown <= 0f)
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

        for (int i = 0; i<waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    void SpawnEnemy()
    {
        Instantiate(attackDronePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
