using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject capsulePrefab;
    private float spawnRange = 20;
    public int waveNumber = 0;
    public int enemyCount = 2;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(waveNumber);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemies(waveNumber);
        }
    }

    void SpawnEnemies(int enemiesToSpawn)
    {

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(cubePrefab, GenerateSpawnPosition(), transform.rotation);
                Instantiate(capsulePrefab, GenerateSpawnPosition(), transform.rotation);
            }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 1, spawnPosZ);
        return randomPos;
    }
}
