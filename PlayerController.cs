using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject rockPrefab;
    private Rigidbody playerRb;
    private Animator playerAnim;
 
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.SetTrigger("Throw");
            StartCoroutine(ThrowCoroutine());
        }
    }

    IEnumerator ThrowCoroutine()
    {
        yield return new WaitForSeconds(2);
        Instantiate(rockPrefab);
    }
}
