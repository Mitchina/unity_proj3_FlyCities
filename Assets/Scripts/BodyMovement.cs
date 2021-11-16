using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{
    public GameObject head;
    public GameObject shoulder;

    public GameObject leg1;
    public GameObject leg2;

    Vector3 bodyOriginalLocalP;
    Quaternion bodyOriginalLocalR;

    Transform leg1Pos;

    private void Awake()
    {
        bodyOriginalLocalP = transform.localPosition;
        bodyOriginalLocalR = transform.localRotation;

        leg1Pos = leg1.GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bodyOriginalLocalP != transform.position)
        {
            Debug.Log("Body moved");
            leg1Pos.position = transform.position;

        }
        if (bodyOriginalLocalR != transform.rotation)
        {
            Debug.Log("Body rotated");
        }
    }
}
