using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public AudioClip manBirdSquawk;

    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    public TextMeshProUGUI victoryText;
    public Button nextLevel;

    public bool isGameActive;
    public int currentSceneIndex;
    public int lastSceneIndex = 11;

    public Button learnMore;

    public bool GameIsOver;

    public Scene scene;

    private PlayerController playerController;
    private Animator playerAnim;

    private Animator policeAnim;

    void Start()
    {
        isGameActive = true;
        WhichBuildIndex();
        currentSceneIndex = scene.buildIndex;
        IsGameComplete();
        rocksLeft = 3;
        UpdateRockCount(0);

        playerAudio = GetComponent<AudioSource>();

        // playerAnim = GameObject.Find("Player").GetComponent<Animator>();

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        policeAnim = GameObject.Find("PoliceOfficer").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rocksLeft < 0)
        {
            GameOver();
        }
    }

    public void UpdateRockCount(int rockToSubtract)
    {
        rocksLeft = rocksLeft - rockToSubtract;
        rockCount.text = "Rocks: " + rocksLeft;
    }

    public void PlayGlassAudio()
    {
        playerAudio.PlayOneShot(glassShattering, 0.1f);
    }

    public void PlayBirdNoise()
    {
        playerAudio.PlayOneShot(manBirdSquawk, 0.1f);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
        playerAudio.Stop();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Scene1", LoadSceneMode.Single);
    }

    public void LevelVictory()
    {
        victoryText.gameObject.SetActive(true);
        nextLevel.gameObject.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public int WhichBuildIndex()
    {
        scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene name is: " + scene.name + "\nActive Scene index: " + scene.buildIndex);
        return scene.buildIndex;
    }

    public void IsGameComplete()
    {
        if (currentSceneIndex < lastSceneIndex)
        {
            GameIsOver = false;
            Debug.Log("GameIsNotOver");
        }
        else
        {
            Debug.Log("GameIsOver");
            isGameActive = false;
            GameIsOver = true;

            //playerAnim.SetBool("GameIsOver", true);
            // playerAnim.SetTrigger("DanceParty");
            playerController.DanceParty();

            policeAnim.SetFloat("Speed_f", 0.0f);
            //policeAnim.SetBool("GameIsOver", true);
            policeAnim.SetTrigger("DanceParty");
        }

    }
}
