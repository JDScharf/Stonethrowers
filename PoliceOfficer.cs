using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceOfficer : MonoBehaviour
{
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
    }
}