using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// to use the constructor, remove the monobehaviour 
// to trigger a function after some time
public class FunctionTimer
{
    // cancel active timers
    static List<FunctionTimer> activeTimerList;

    static GameObject initGameObject;

    // we need to init this list, to make sure everything is contained in that class:
    static void InitIfNeeded()
    {
        // you can use the gameobject to see if it is still alive or have been destroyed
        if(initGameObject == null)
        {
            // that means that this class is running for the very first time or already reset
            initGameObject = new GameObject("FunctionTimer_InitGameObject");
            activeTimerList = new List<FunctionTimer>();
        }
    }

    // as the timerName is optional, set it to null
    public static FunctionTimer CreateFunctionAfterTime(Action action, float timer, string timerName=null)
    {
        // if it is necessary to init the list:
        InitIfNeeded();
        GameObject gameObject = new GameObject("FunctionTimer", typeof(MonoBehaviourHook));

        FunctionTimer functionTimerVar = new FunctionTimer(action, timer, timerName, gameObject);
        
        // set the on.Update function to trigger the functionTimer.Update();
        
        gameObject.GetComponent<MonoBehaviourHook>().actionOnUpdate = functionTimerVar.TimerUpdate;

        // add it to our previous activeTimerList list
        // our list will only contains the active timers
        activeTimerList.Add(functionTimerVar);

        return functionTimerVar;
    }

    // function to remove functionTimerVar to the list
    // call this function when we DestroySelf()
    static void RemoveTimerFromList(FunctionTimer functionTimerVar)
    {
        // to make sure that list exists:
        InitIfNeeded();
        activeTimerList.Remove(functionTimerVar);
    }

    // stop a certain timer
    public static void StopTimer(string timerName)
    {
        // we need some way to identify the timers, so we use a string with timerName
        // we need to init FunctionTimer and also give it a name
        for (int i = 0; i < activeTimerList.Count; i++)
        {
            // if the actual name of that item in the list is the same name that we want to stop, so: stop it
            if(activeTimerList[i].timerName == timerName)
            {
                // Stop this timer
                activeTimerList[i].DestroySelf();
                i--;
            }
        }
    }
    
    // Dummy class to have access to MonoBehaviour functions
    private class MonoBehaviourHook : MonoBehaviour
    {
        // we can store here the action for the Update
        public Action actionOnUpdate;
        // which means that inside here, we have access to the Update
        private void Update()
        {
            // trigger the action
            if(actionOnUpdate != null) actionOnUpdate();
        }
    }


    
    // make the constructor:
    // we will receive an action, which is inside (using System;), that takes no parameter and returns void
    // and we will receive a float for the timer

    Action action;
    float timer;
    string timerName;
    bool isDestroyed;
    GameObject gameObject;

    // the constructor will be private after the creation of CreateFunctionAfterTime()
    // now, the FunctionTimer() will be called inside CreateFunctionAfterTime()
    // we will need to clean that gameObject after the action is triggered
    // receive the gameObject as parameter to destroy it later
    private FunctionTimer(Action action, float timer, string timerName, GameObject gameObject)
    {
        this.action = action;
        this.timer = timer;
        this.timerName = timerName;
        this.gameObject = gameObject;
        // by default the boolean is not destroyed
        isDestroyed = false;
    }

    // make a function that will run on Update
    // to make this class better, we need to call the TimerUpdate() inside this class
    // have another simple class inside this class that hooks into the monobehaviour
    private void TimerUpdate()
    {
        // and we only run this code if the boolean arre not destroyed
        if (!isDestroyed)
        {
            timer -= Time.deltaTime;
            //Debug.Log($"Timer countdown {timer}");
            if (timer <= 0)
            {
                // Trigger the action!
                // as the action is a function, we just call it
                action();
                // we are going to destroy the function action after trigger the action it
                DestroySelf();
            }
        }        
    }
    void DestroySelf()
    {
        // to destroy it, we are gonna set a boolean
        isDestroyed = true;
        // also destroy our gameObject.
        UnityEngine.Object.Destroy(gameObject);
        RemoveTimerFromList(this);
    }



    
}
