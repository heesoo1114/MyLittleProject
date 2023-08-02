using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;

    public float maxHeight;
    public float minHeight;

    public float delayTime;

    public void SpawnStart()
    {
        StartCoroutine(PipeSpawn());
    }

    public void SpawnStop()
    {
        StopCoroutine(PipeSpawn());
    }

    IEnumerator PipeSpawn()
    {
        while (true)
        {
            float randomHeight = Random.Range(minHeight, maxHeight);

            GameObject pipe = Instantiate(pipePrefab);
            pipe.transform.SetParent(transform);
            pipe.transform.position = new Vector3(transform.position.x, randomHeight, 0);

            yield return new WaitForSeconds(delayTime);
        }
    }
}
