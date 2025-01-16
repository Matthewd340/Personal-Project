using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float forwardInput;
    public float speed = 5;
    public float rotateSpeed = 50;
    public float xRange = 100;
    public float zRange = 100;
    private Rigidbody playerRb;
    public GameObject projectilePrefab;
    public bool gameOver = false;
    public int pushbackForce = 20;
    public float dashSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Debug.Log("Use WASD or arrow keys to move, Left Shift to dash, Space to shoot, Tab to flip player. Good luck!");
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * forwardInput);
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * horizontalInput);

         if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        //top if statement keeps player above negative xRange, bottom keeps below xRange
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if(transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        //top if statement keeps player above negative zRange, bottom keeps below zRange
        if(transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            transform.Rotate(Vector3.up * 180);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.forward * dashSpeed * Time.deltaTime * forwardInput);
        }
    }

    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidbody.AddForce(awayFromPlayer * pushbackForce, ForceMode.Impulse);
            Destroy(gameObject);
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }
}
