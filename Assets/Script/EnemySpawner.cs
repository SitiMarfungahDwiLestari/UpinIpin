using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject ghostPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 5f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnGhost();
            timer = 0f;  // Reset timer setelah spawn
        }
    }

    public void SpawnGhost()
    {
        Instantiate(ghostPrefab, spawnPoint.position, Quaternion.identity);
    }
}