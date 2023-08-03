using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy; // enemyPrefab
    public List<Transform> spawnPosition;
    public int spawnCount = 0;
    public int waveCount = 1;
    public int lastWave = 5;

    public UnityEvent<int> WaveChange;
    public UnityEvent WaveClear;

    [ContextMenu("Spawn")]
    public void SpawnStart(int enemyCount, float delayTime)
    {
        StartCoroutine(Spawn(enemyCount, delayTime));
    }

    public void SpawnStop()
    {
        StopAllCoroutines();
    }

    public void NextWave(int enemyCount, float delayTime)
    {
        waveCount++;

        if (waveCount > lastWave) 
        {
            WaveClear?.Invoke();
            SpawnStop();
        }
        else
        {
            WaveChange?.Invoke(waveCount);
        }

        StartCoroutine(Spawn(enemyCount, delayTime));
    }

    IEnumerator Spawn(int enemyCount, float delayTime)
    {
        while (true)
        {
            if (spawnCount >= enemyCount)
            {
                yield return new WaitForSeconds(delayTime);
                NextWave(enemyCount * 2, delayTime - 0.5f);
                yield break;
            }

            yield return new WaitForSeconds(delayTime);
            int randomPositionNumber = Random.Range(0, spawnPosition.Count);
            Instantiate(enemy, spawnPosition[randomPositionNumber].position, Quaternion.identity);
            spawnCount++;
        }
    }
}
