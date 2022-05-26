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

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "washroom")
        {
            //jos tämän rivin ottaa pois niin kursori vaihtuu halutusti, mutta obviously klikkaaminen ei toimi.
            controls = new CursorControls();

            ChangeCursor(cursor);
            controls.Mouse.Click.started += _ => StartedClick();
            controls.Mouse.Click.performed += _ => EndedClick();
            controls.Enable();
        }
        else
        {
            //en pysty disableemaan niitä kontrolleja et se hiiri vaihtuis ja silti washroom skenessä vois klikata.
            //ne kontrollit jostain syystä pakottaa sen sienikuvan siihen.
            ChangeCursorNormal(normalcursor);
            controls.Disable();
        }
    }



    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


    private void StartedClick()
    {
        ChangeCursor(cursorClicked);
    }

    private void EndedClick()
    {
            ChangeCursor(cursor);
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
