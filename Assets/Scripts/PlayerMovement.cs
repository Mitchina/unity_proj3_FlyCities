using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerRb;

    [SerializeField] float boostLevel = 1000f;
    [SerializeField] float rotationSpeed = 100f;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Boosting();
        MovingBackAndForward();        
        //MovingRotation();
    }
    void Boosting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // freezing the rotation so we can manually rotate
            playerRb.freezeRotation = true;
            //Debug.Log("The Space key was pressed");
            playerRb.AddRelativeForce(Vector3.up * boostLevel * Time.deltaTime);
        }
    }

    void MovingBackAndForward()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("Going Forward"); // Rotate - the rotation Z axis
            ApplyMyBFRotation(Vector3.back);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("Going Backward");// Rotate the rotation Z axis
            ApplyMyBFRotation(Vector3.forward);
        }
    }
    private void ApplyMyBFRotation(Vector3 backOrForward)
    {
        // freezing the rotation so we can manually rotate
        playerRb.freezeRotation = true;
        transform.Rotate(backOrForward * rotationSpeed * Time.deltaTime);
        // then unfreezing it
        playerRb.freezeRotation = false;
    }

    /*
    void MovingRotation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // Debug.Log("Rotating Left"); // Rotate the X axis
            ApplyMyLRRotation(1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("Rotating Right"); // Rotate - the X axis
            ApplyMyLRRotation(-1);
        }
    }
    private void ApplyMyLRRotation(float XAxisPlusOneOrMinusOne)
    {
        // freezing the rotation so we can manually rotate
        playerRb.freezeRotation = true;
        transform.Rotate(XAxisPlusOneOrMinusOne, 0, 0);
        // then unfreezing it, so the physics system can take over
        playerRb.freezeRotation = false;
    }
    */
}
