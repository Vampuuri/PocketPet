using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClick : MonoBehaviour

{
    public GameObject PetSleepObject;
    private PetAttributes PetSleep;

    public void ToGameScene()
    {
        if (PetAttributes.SleepMode == false)
        {
            SceneManager.LoadScene("runnergame");
            PetAttributes.energy -= PetAttributes.GameEnergyLoss;
        }
        else
            Debug.Log("not now im sleeping!");
    }

    public void ToWashroomScene()
    {
        if (PetAttributes.SleepMode == false)
        {
            SceneManager.LoadScene("washroom");
        }
        else
            Debug.Log("not now im sleeping!");
    }

    void EnergySource()
    {
        PetSleepObject = GameObject.Find("EssinManager");

    }

    void Awake()
    {
        PetSleep = GetComponent<PetAttributes>();
    }

    public void OnMouseDown()
    {

    }
}