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
        SceneManager.LoadScene("runnergame");
        Debug.Log("check");
        PetAttributes.energy -= PetAttributes.GameEnergyLoss;
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