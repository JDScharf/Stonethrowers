using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustForward : MonoBehaviour
{
    private Rigidbody rockRb;
    public float throwForce = 10f;
    private float sideBound = 25f;
    private GameObject trafficLight;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rockRb = GetComponent<Rigidbody>();
        trafficLight = GameObject.Find("Traffic Light");
    }

    // Update is called once per frame
    void Update()
    {
        rockRb.AddForce(0, throwForce, throwForce, ForceMode.Impulse);

        if (transform.position.z > sideBound)
        {
            Destroy(gameObject);
        }
    }

    // Causes an action if the rock hits a bird
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bird"))
        {
            Debug.Log("Blimey, that rock hit a Bird");
        }
    }

    // Causes the rock to break the Traffic Light
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Traffic Light"))
        {
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Portal"))
        {
            transform.position = new Vector3(transform.position.x, 4, 15);
            Vector3 lookDirection = (trafficLight.transform.position - transform.position).normalized;
            rockRb.AddForce(lookDirection * speed);
        }
    }
}
