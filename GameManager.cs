using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI rockCount;
    private int rocksLeft;
    private GameObject trafficLight;

    //  public TextMeshProUGUI throwForceBar;
    //  private int throwForceValue;
    private PlayerController playerScript;

    [SerializeField] GameObject brokenLight;
    [SerializeField] ParticleSystem explosionParticle;

    private AudioSource playerAudio;
    public AudioClip glassShattering;
    // public AudioClip irishDrumMusic;

    //Play the music
    // bool m_Play;

    // Start is called before the first frame update
    void Start()
    {
        rocksLeft = 3;
        UpdateRockCount(0);

        playerAudio = GetComponent<AudioSource>();
        // m_Play = true;

        //Check to see if the game is active
        // if (m_Play == true)
        {
            //Play the audio you attach to the AudioSource component
        //    playerAudio.Play();
        //    Debug.Log("started at: " + Time.deltaTime);
        }
       

        //  playerAudio.Play(irishDrumMusic); 

        //  playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //  playerScript.throwForceUp = throwForceValue;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (m_Play == false)
        {
            playerAudio.Stop();
        }
        */
    }

    public void UpdateRockCount(int rockToSubtract)
    {
        rocksLeft = rocksLeft - rockToSubtract;
        rockCount.text = "Rocks: " + rocksLeft;
    }

    public void PlayGlassAudio()
    {
        playerAudio.PlayOneShot(glassShattering, 0.1f);
        // m_Play = false;
    }

}
