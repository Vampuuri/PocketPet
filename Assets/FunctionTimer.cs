using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FunctionTimer
{
    public static FunctionTimer Create(Action action, float timer)
    {
        GameObject gameObject = new GameObject("FunctionTimer", typeof(MonoBehaviourHook));

        FunctionTimer functionTimer = new FunctionTimer(action, timer, gameObject);

        gameObject.GetComponent<MonoBehaviourHook>().onUpdate = functionTimer.Update;

        return functionTimer;
    }

    //tämä on tässä to abuse monobehavior functions
    public class MonoBehaviourHook : MonoBehaviour
    {
        public Action onUpdate;
        private void Update()
        {
            if (onUpdate != null) onUpdate();
        }
    }

    private Action action;
    private float timer;
    private GameObject gameObject;
    private bool isDestroyed;

    private FunctionTimer(Action action, float timer, GameObject gameObject)
    {
        this.action = action;
        this.timer = timer;
        this.gameObject = gameObject;
        isDestroyed = false;
    }

    public void Update()
    { if (isDestroyed == false)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                //Trigger the action, tässä tapauksessa siirretään nappi näkyviin probably
                action();
                DestroySelf();
            }
        }
    }
    private void DestroySelf()
    {
        isDestroyed = true;
        UnityEngine.Object.Destroy(gameObject);
    }
}
