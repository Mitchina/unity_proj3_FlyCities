using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManMoviments : MonoBehaviour
{
    public Transform head;
    public Transform body;
    public Transform shoulder;

    Vector3 bodyOriginalLocalP;
    Quaternion bodyOriginalLocalR;

    Vector3 headOriginalLocalP;
    Quaternion headOriginalLocalR;

    private void Awake()
    {
        bodyOriginalLocalP = body.localPosition;
        bodyOriginalLocalR = body.localRotation;
    }

    //Transform bodyT;
    //Rigidbody bodyRbForce;

    // Start is called before the first frame update
    void Start()
    {
        //manT = GetComponent<Transform>();
        //bodyT = body.GetComponent<Transform>();
        //bodyRbForce = body.GetComponent<Rigidbody>();

        //manT.position = bodyT.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(bodyOriginalLocalP != body.localPosition)
        {
            transform.position = body.position;
        }
        
    }
}
