using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficScript : MonoBehaviour
{
    private Rigidbody trafficLightRb;
    public float maxTorque = 1;


    // Start is called before the first frame update
    void Start()
    {
        trafficLightRb = GetComponent<Rigidbody>();
        trafficLightRb.AddTorque(0, RandomTorque(), 0, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float RandomTorque()
    {
        return Random.Range(.1f, maxTorque);
    }
}
