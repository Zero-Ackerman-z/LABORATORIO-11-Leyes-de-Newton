using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public PipeConfiguration pipeConfig;
    public GameObject pipePrefab;
    public float spawnInterval = 1f;
    public float pipeSpeed = 1f;

    private float timer;

    private void Start()
    {
        timer = spawnInterval;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnPipe();
            timer = spawnInterval;
        }

        MovePipes();
    }


    private void SpawnPipe()
    {
        float randomYPosition = Random.Range(pipeConfig.minHeight, pipeConfig.maxHeight);
        GameObject newPipe = Instantiate(pipePrefab, new Vector3(transform.position.x, randomYPosition, 0), Quaternion.identity);
    }

    private void MovePipes()
    {
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");

        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i].transform.Translate(Vector3.left * pipeSpeed * Time.deltaTime);
        }
    }
    

}

