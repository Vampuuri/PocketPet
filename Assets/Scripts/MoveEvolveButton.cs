using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveEvolveButton : MonoBehaviour
{

    private FunctionTimer functionTimer;
    public GameObject myButton;


    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        FunctionTimer.Create(MoveButton, 3f);
    }

    private void MoveButton()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        bool inGame = currentScene.name == "gamescreen";

        PlayerPrefs.SetInt("EvolveBool", 1);
        if (inGame)
        {
            bool inGameAgain = inGame == true;
            Debug.Log(PlayerPrefs.GetInt("EvolveBool"));
            if (inGameAgain == false)
            {
                if (PlayerPrefs.GetInt("EvolveBool") == 1)
                {
                    Debug.Log("successful button move");
                    GameObject evolveButton = GameObject.Find("EvolveButton");
                    evolveButton.transform.Translate(Vector2.down * 7f);
                    PlayerPrefs.SetInt("EvolveBool", 0);
                    inGameAgain = true;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("evolved");
    }

}