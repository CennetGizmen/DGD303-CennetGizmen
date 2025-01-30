using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] float waveCooldown;


    [Header("Essentials")]
    [SerializeField] GameObject[] enemyPrefabs;

    [SerializeField] Transform[] spawnPoints;

    int currentWaveNumber = 1;


    int currentSpawnPointNumber = 0;

    float waveTimer;

  public  List<GameObject> currentEnemies = new List<GameObject>();

    bool canFinish = false;

    private void Start()
    {
        waveTimer = waveCooldown - 1;
    }
    void Update()
    {
        waveTimer += Time.deltaTime;
        if (waveTimer >= waveCooldown)
        {
            WaveInfo(currentWaveNumber);
            currentWaveNumber++;
            waveTimer = 0;
        }
        if (canFinish)
        {
            if (currentEnemies.Count == 0)
            {
                GameManager.Instance.GameWin();
            }
        }
    }

    IEnumerator WaveSpawn(int amount, int enemyTypeNumber, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i < amount; i++)
        {
            GameObject currentEnemy = Instantiate(enemyPrefabs[enemyTypeNumber], spawnPoints[currentSpawnPointNumber].position, Quaternion.identity);

            currentEnemy.GetComponent<Enemy>().waveSpawner = this;
            currentEnemies.Add(currentEnemy);
            SpawnPointCheck();
            yield return new WaitForSeconds(0.5f);
            waveTimer -= 0.5f;
            //Bu bekleme süresi eklenmeli
        }
    }


    void SpawnPointCheck()

    {
        if (currentSpawnPointNumber < 5)
        {
            currentSpawnPointNumber++;
        }
        else
        {
            currentSpawnPointNumber = 0;
        }

    }
    void WaveInfo(int waveNumber)
    {
        if (waveNumber == 1)
        {
            StartCoroutine(WaveSpawn(6, 0, 0));
        }
        else if (waveNumber == 2)

        {
            StartCoroutine(WaveSpawn(6, 0, 0));
            StartCoroutine(WaveSpawn(3, 1, 3.5f));

        }
        else if (waveNumber == 3)

        {
            GameManager.Instance.ChangeBullet(1);
            StartCoroutine(WaveSpawn(6, 0, 0));
            StartCoroutine(WaveSpawn(4, 1, 3));
            StartCoroutine(WaveSpawn(2, 2, 5.5f));
        }
        else if (waveNumber == 4)

        {
            StartCoroutine(WaveSpawn(9, 0, 0));
            StartCoroutine(WaveSpawn(6, 1, 5));
            StartCoroutine(WaveSpawn(3, 2, 9.5f));
        }
        else if (waveNumber == 5)

        {
            GameManager.Instance.ChangeBullet(2);
            StartCoroutine(WaveSpawn(9, 0, 0));
            StartCoroutine(WaveSpawn(9, 1, 5.5f));
            StartCoroutine(WaveSpawn(9, 2, 12));

            StartCoroutine(FinishingGame());
        }

        IEnumerator FinishingGame()
        {
            yield return new WaitForSeconds(6);
            canFinish = true;
        }
    }
}
