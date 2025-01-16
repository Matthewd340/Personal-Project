using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Rigidbody projectileRb;
    public float xRange = 120;
    public float zRange = 120;
    public float score;

    // Start is called before the first frame update
    void Start()
    {
        projectileRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -xRange)
        {
            Destroy(gameObject);
        }
        //top if statement keeps player above negative xRange, bottom keeps below xRange
        if(transform.position.x > xRange)
        {
            Destroy(gameObject);
        }

        if(transform.position.z < -zRange)
        {
            Destroy(gameObject);
        }
        //top if statement keeps player above negative zRange, bottom keeps below zRange
        if(transform.position.z > zRange)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
