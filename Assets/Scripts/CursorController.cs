using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorController : MonoBehaviour
{
    public Texture2D normalcursor;
    public Texture2D cursor;
    public Texture2D cursorClicked;
    private CursorControls controls;

    public GameObject CursorControllerObject;

    public static CursorController instance;

    private void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        bool inWashroom = currentScene.name == "washroom";
        CursorControllerObject = GameObject.Find("CursorController");

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(CursorControllerObject);
        }

        string sceneName = currentScene.name;

            controls = new CursorControls();

            controls.Mouse.Click.started += _ => StartedClick();
            controls.Mouse.Click.performed += _ => EndedClick();
            controls.Enable();

        if (inWashroom)
        {
            ChangeCursor(cursor);
        }
        else
        {
            ChangeCursorNormal(normalcursor);
        }
    }


    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        //not set to an instance of an object?
        controls.Disable();
    }


    private void StartedClick()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        bool inWashroom = currentScene.name == "washroom";
        if (inWashroom)
        {
            ChangeCursor(cursorClicked);
        }
    }

    private void EndedClick()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        bool inWashroom = currentScene.name == "washroom";
        if (inWashroom)
        {
            ChangeCursor(cursor);
        }
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        Cursor.SetCursor(cursorType, hotspot, CursorMode.ForceSoftware);
    }

    private void ChangeCursorNormal(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }
}
