using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlying : MonoBehaviour
{
    private Rigidbody birdRb;
    public float speed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        birdRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > 14)
            {
                birdRb.AddForce(Vector3.forward * -speed);
            }
            else if (transform.position.z < 6)
            {
                birdRb.AddForce(Vector3.forward * speed);
            }
        }
    }
