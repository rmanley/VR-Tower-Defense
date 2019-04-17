using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Enemy drone;
    public Enemy attackDrone;

    public Transform spawnPoint;
    public Transform endPoint;

    public float timeBetweenWaves = 3f;
    private float countdown = 3f;

    public Text waveCountdownText;

    public static int waveIndex = 0;
    public static int enemyCount = 0;

    private void Awake()
    {
        countdown = 3f;
        waveIndex = 0;
        enemyCount = 0;
    }

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        if(enemyCount == 0) countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex/2 + 1; i++)
        {
            enemyCount++;
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Transform enemy = drone.transform;
        float ad = 0.5f;
        float attack = 0.5f;
        if (Random.value > ad) enemy = drone.transform;
            else enemy = attackDrone.transform;
        if (Random.value < attack)
        {
            drone.Strategy = EnemyStrategy.Attack;
            attackDrone.Strategy = EnemyStrategy.Attack;
        }
        else
        {
            drone.Strategy = EnemyStrategy.Passive;
            attackDrone.Strategy = EnemyStrategy.Passive;
        }
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
