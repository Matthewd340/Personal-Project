using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject capsulePrefab;
    private Vector3 capsuleSpawnPos = new Vector3(-5, 1, 7);
    private Vector3 cubeSpawnPos = new Vector3(5, 1, 7);
    public float startDelay = 2;
    public float repeatRate = 2;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies()
    {
        if (playerControllerScript.gameOver == false)
        {
        Instantiate(cubePrefab, cubeSpawnPos, transform.rotation);
        Instantiate(capsulePrefab, capsuleSpawnPos, transform.rotation);
        }
    }
}
