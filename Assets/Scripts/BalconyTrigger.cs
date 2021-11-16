using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalconyTrigger : MonoBehaviour
{
    //private void OnTriggerEnter(Collider other)
    //{
    //    //Debug.Log(other.gameObject.tag);
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Debug.Log("Press F to enter in this apartment");
    //    }
    //}

    //FunctionTimer functionTimerVar;

    
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("If you stay 5 seconds in front of this window you can enter in this apartment");
            // call the FunctionTimer with the time and the action you want: // remember we still need to call the TimerUpdate method
            // as the FunctionTimer is running with the monobehaviour, we can access its TimerUpdate method
            // let's store this function in a variable 
            /*functionTimerVar = new FunctionTimer(WannaEnterInThisBalcony, 0.02f);
            functionTimerVar.TimerUpdate();*/
            FunctionTimer.CreateFunctionAfterTime(WannaEnterInThisBalcony, 0.02f, "Timer 1 second");
            //FunctionTimer.CreateFunctionAfterTime(WannaEnterInThisBalcony, 0.5f);
        }
    }   

    // Create an action to occurr after 5 seconds in front of the balcony window
    void WannaEnterInThisBalcony()
    {
        //Debug.Log("You stayed 5 seconds in here, would you like enter in this apartment?");
        Debug.Log("Would you like enter in this apartment?");
    }

    // I would then also reset if player leaves the collider
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FunctionTimer.StopTimer("Timer 1 second");
        }
    }
}
