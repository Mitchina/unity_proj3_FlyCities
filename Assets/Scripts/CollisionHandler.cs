using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);

        ////int i = 0;
        //for (int i = 0; i < 10; i++)
        //{
        //    Debug.Log($"{collision.contacts[i]}");
        //}
        ////for i in collision.contacts[i].thisCollider;            
        ////Collider myCollider = collision.contacts[0].thisCollider;
        switch (collision.gameObject.tag)
        {
            case "BuildingBalcony":
                Debug.Log("You've passed in front of a building balcony");
                break;
            case "TowerBalcony":
                Debug.Log("Tower Balcony");
                break;
            case "Untagged":
                break;
        }
    }
}
