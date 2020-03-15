using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject bird;
    public GameObject policeOfficer;
    public GameObject portalStart;
    public GameObject portalEnd;

    private float xPosition = 0;
    private float zPositionBird = -15f;

    private float birdsStartTime = 1;
    private float birdsRepeatTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        //SpawnPoliceOfficer();
        // InvokeRepeating("SpawnRandomBirdPosition", birdsStartTime, birdsRepeatTime);
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    void SpawnRandomBirdPosition()
    {
        float randomY = Random.Range(5, 10f);
        Vector3 spawnPosBird = new Vector3(xPosition, randomY, zPositionBird);
        Instantiate(bird, spawnPosBird, bird.transform.rotation);
    }
}
