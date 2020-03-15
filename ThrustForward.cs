using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustForward : MonoBehaviour
{
    public Rigidbody rockRb;
    private GameObject trafficLight;
    private Rigidbody arrowPointerRb;
    private PlayerController playerScript;
    private GameManager gameManager;

    public float throwForce = 0;
    private float velocityY;
    private float velocityZ;

    [SerializeField] GameObject brokenLight;
    [SerializeField] ParticleSystem explosionParticle;

    private float sideBound = 35f;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rockRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        trafficLight = GameObject.Find("Traffic Light");

        velocityZ = Mathf.Cos(45) * throwForce;
        velocityY = Mathf.Sin(45) * throwForce;

        rockRb.AddRelativeForce(Vector3.forward * throwForce, ForceMode.Impulse);

        // this code works :)
        // rockRb.AddForce(0, velocityY, velocityZ, ForceMode.Impulse);

        // arrowPointerRb = GameObject.Find("ArrowPointer").GetComponent<Rigidbody>();
        // transform.position = arrowPointerRb.transform.position;
        // transform.rotation = arrowPointerRb.transform.rotation;
    }

    // Update is called once per frame
    void Update()

    /*    Old ThrustForward Code
        {
            rockRb.AddForce(0, throwForceY, throwForceZ, ForceMode.Impulse);
        }
    */
    {
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
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Instantiate(brokenLight);
            gameManager.PlayGlassAudio();
        }
        else if(other.gameObject.CompareTag("Portal"))
        {
            transform.position = new Vector3(transform.position.x, 4, 15);
            Vector3 lookDirection = (trafficLight.transform.position - transform.position).normalized;
            rockRb.AddForce(lookDirection * speed);
        }
    }
}
