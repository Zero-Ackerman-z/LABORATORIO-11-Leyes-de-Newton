using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public PipeConfiguration pipeConfig;
    public GameObject pipePrefab;
    public float spawnInterval = 2f;
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

        MovePipes(); // Llamar al m�todo para mover las tuber�as
    }

    private void SpawnPipe()
    {
        float randomYPosition = Random.Range(pipeConfig.minHeight, pipeConfig.maxHeight);
        GameObject newPipe = Instantiate(pipePrefab, new Vector3(transform.position.x, randomYPosition, 0), Quaternion.identity);
    }

    private void MovePipes()
    {
        // Obtener todas las tuber�as en la escena
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");

        // Mover cada tuber�a hacia la izquierda
        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i].transform.Translate(Vector3.left * pipeSpeed * Time.deltaTime);
        }
    }
}
