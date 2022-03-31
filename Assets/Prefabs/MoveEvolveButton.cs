using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        GameObject evolveButton = GameObject.Find("EvolveButton");
        evolveButton.transform.Translate(Vector2.down * 7f);
    }

    private void OnMouseDown()
    {
        Debug.Log("evolved");
    }
}