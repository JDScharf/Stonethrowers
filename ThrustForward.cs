using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustForward : MonoBehaviour
{
    public Rigidbody rockRb;
    private GameObject trafficLight;
    private GameObject portalEnd;

    private Rigidbody arrowPointerRb;
    private PlayerController playerScript;
    private GameManager gameManager;

    public float throwForce = 0;
    private float velocityY;
    private float velocityZ;

    [SerializeField] GameObject brokenLight;
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] ParticleSystem smokeParticle;

    private float sideBound = 35f;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rockRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        trafficLight = GameObject.Find("Traffic Light");
        portalEnd = GameObject.Find("PortalEnd");

        velocityZ = Mathf.Cos(45) * throwForce;
        velocityY = Mathf.Sin(45) * throwForce;

        rockRb.AddRelativeForce(Vector3.forward * throwForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
            if (transform.position.z > sideBound)
            {
                Destroy(gameObject);
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
            gameManager.LevelVictory();

        }

        else if(other.gameObject.CompareTag("Portal"))
        {
            Destroy(gameObject);
            Instantiate(playerScript.rockPrefab, portalEnd.transform.position, portalEnd.transform.rotation);
        }

        else if (other.gameObject.CompareTag("Bird"))
        {
            Destroy(gameObject);
            Instantiate(smokeParticle, other.gameObject.transform.position, smokeParticle.transform.rotation);
            gameManager.PlayBirdNoise();
            Debug.Log("Blimey, that rock hit a Bird");
        }
    }
}
