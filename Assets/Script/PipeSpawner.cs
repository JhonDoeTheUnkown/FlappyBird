using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnTime;
    public float ymin,ymax; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnPipeCoroutine());
    }

    IEnumerator SpawnPipeCoroutine()
    {
        
        yield return new WaitForSeconds(spawnTime);
        Instantiate(pipe, transform.position + Vector3.up * Random.Range(ymin,ymax), Quaternion.identity);
        StartCoroutine(SpawnPipeCoroutine());
    }
}
