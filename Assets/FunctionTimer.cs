using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FunctionTimer
{
    public static FunctionTimer Create(Action action, float timer)
    {
        FunctionTimer functionTimer = new FunctionTimer(action, timer);

        GameObject gameObject = new GameObject("FunctionTimer", typeof(MonoBehaviourHook));
        gameObject.GetComponent<MonoBehaviourHook>().onUpdate = functionTimer.Update;

        return functionTimer;
    }

    //t�m� on t�ss� to abuse monobehavior functions
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
    private bool isDestroyed;

    private FunctionTimer(Action action, float timer)
    {
        this.action = action;
        this.timer = timer;
        isDestroyed = false;
    }

    public void Update()
    { if (isDestroyed == false)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                //Trigger the action, t�ss� tapauksessa siirret��n nappi n�kyviin probably
                action();
                DestroySelf();
            }
        }
    }
    private void DestroySelf()
    {
        isDestroyed = true;
    }
}
