using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEvolveButton : MonoBehaviour
{

    private FunctionTimer functionTimer;

    private void Start()
    {
        FunctionTimer.Create(MoveButton, 3f);
    }

    private void MoveButton()
    {
        Debug.Log("successful button move");
    }
}
