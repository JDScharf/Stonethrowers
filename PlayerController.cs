using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject rockPrefab;
    private Rigidbody rockRb;
    private Rigidbody playerRb;
    public Animator playerAnim;
    private GameManager gameManager;
    private ThrustForward thrustScript;
    public float throwForceUp = 0;
    
    public GameObject arrowPointer;
    private float verticalInput;
    [SerializeField] float rotateSpeed;

    // private float arrowMaxValueX = 90;
    // private float arrowMinValueX = 0;
    // float arrowY;
    // float arrowZ;
    // private Vector3 arrowCurrentEulerAngles;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();

        playerRb = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        thrustScript = rockPrefab.GetComponent<ThrustForward>();
    }

    // Update is called once per frame
    void Update()
    {
        playerAnim.SetFloat("Speed_f", 0.0f);

        AdjustThrowAngle();

        if (gameManager.isGameActive == true)
        {
            ThrowStone();
        }

        if (gameManager.currentSceneIndex == 11)
        {
            playerAnim.SetTrigger("DanceParty");
        }

        /*
               if (arrowPointer.transform.rotation.x > arrowPointerMaxPos)
               {
                   transform.rotation.x = arrowPointerMaxPos;
               }            

                   arrowPointerMaxPos)
               {
                   arrowPointer.transform.rotation = arrowPointer.transform.Rotate

                       (arrowPointerMaxPos, 2.54f, .4f, Space.Self);
               }
               */
        // while (gameManager.isGameActive)
        //   {
        // }
    }

    public void ThrowStone()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            OnSpaceBarHold();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerAnim.SetTrigger("Throw");
            StartCoroutine(ThrowCoroutine());
        }
    }

    public void DanceParty()
    {
        playerAnim.SetTrigger("DanceParty");
    }

        void AdjustThrowAngle()
    {
        verticalInput = Input.GetAxis("Vertical");

        arrowPointer.transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed * -verticalInput);
    }
    /*
    if (arrowPointer.transform.eulerAngles.x < -90.0f)
    {
        arrowPointer.transform.eulerAngles = new Quaternion(-90f, 0.0f, 0.0f, );
    }

*/

    float OnSpaceBarHold()
        {   if (throwForceUp < 50)
        {
            throwForceUp += 15 * Time.deltaTime;
            Debug.Log("throwForceUp is now: " + throwForceUp);
        }
            return throwForceUp;
        }

        IEnumerator ThrowCoroutine()
        {
            yield return new WaitForSeconds(1);
            thrustScript.throwForce = throwForceUp;
            rockPrefab.transform.rotation = arrowPointer.transform.rotation;
            Instantiate(rockPrefab);
            gameManager.UpdateRockCount(1);
            throwForceUp = 0;
        }
}
