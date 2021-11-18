using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Tree is saying: {collision.gameObject.tag}");
        if (collision.gameObject.tag == "Player")
            Debug.Log("You died");
    }
}
