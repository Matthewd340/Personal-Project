using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;
    private float enemySpeed = 1;
    private SpawnManager spawnManagerScript;
    private float speedModifier = 1;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        spawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        speedModifier = speedModifier += 0.5f * Time.deltaTime;
        enemySpeed += speedModifier;
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * enemySpeed * Time.deltaTime);
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

    public void IncreaseSpeedPerWave(int waveCount)
    {
        enemySpeed += speedModifier * waveCount;
    }
}
