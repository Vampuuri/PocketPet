using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveEvolveButton : MonoBehaviour
{

    private FunctionTimer functionTimer;
    public GameObject myButton;

    private void Start()
    {
        FunctionTimer.Create(MoveButton, 3f);
    }

    private void MoveButton()
    {
        if (PlayerPrefs.GetInt("EvolveBool") == 0)
        {
            Debug.Log("successful button move");
            GameObject evolveButton = GameObject.Find("EvolveButton");
            evolveButton.transform.Translate(Vector2.down * 7f);
            PlayerPrefs.SetInt("EvolveBool", 1);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("evolved");
    }

}