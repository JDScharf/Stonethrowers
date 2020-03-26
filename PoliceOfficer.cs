using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceOfficer : MonoBehaviour
{
    /*
    private Rigidbody policeRb;
    public float speed = 100f;
    private bool left;

    //    public float leftBound = 5f;
    //    public float rightBound = 15f;
    //    public bool forceRight;

    // Start is called before the first frame update
    void Start()
    {
        policeRb = GetComponent<Rigidbody>();
        left = false;
    
//      forceRight = true;
    }

    // Update is called once per frame
    void Update()
    {
       if (policeRb.transform.position.z >= 9.9f)
        {
            left = true;
            transform.Rotate(0, 180, 0);

        }
       if (left)
        {
            policeRb.transform.Translate(0f, 0f, -2 * Time.deltaTime);
        }

       if (policeRb.transform.position.z <= 3.9f)
        {
            left = false;
        }

       if (!left)
        {
            policeRb.transform.Translate(0f, 0f, 2 * Time.deltaTime);
        }

        /*    if (transform.position.z > 14)
            {
                policeRb.AddForce(Vector3.forward * -speed);
            }
            else if (transform.position.z < 6)
            {
                policeRb.AddForce(Vector3.forward * speed);
            }
        }
        */

    // Patrol.cs

    public Animator policeAnim;
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private GameManager gameManager;

    void Start()
    {
        policeAnim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = true;

        if (gameManager.isGameActive == true)
        {
            GotoNextPoint();
        }
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    
    void Update()
    {
        if (gameManager.isGameActive == true)
        {
            OfficerMovement();
        }
    }

    public void OfficerMovement()
    {
        policeAnim.SetFloat("Speed_f", .3f);
        policeAnim.SetBool("Static_b", true);

        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
