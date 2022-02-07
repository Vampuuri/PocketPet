using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepClick : MonoBehaviour

{
    public GameObject PetSleepObject;

    private PetAttributes PetSleep;


    void HungerSource()
    {
        PetSleepObject = GameObject.Find("EssinManager");

    }

    void Awake()
    {
        PetSleep = GetComponent<PetAttributes>();
    }

    private void Start()
    {
        Debug.Log("The energy is " + PetAttributes.energy);
    }

    private void OnMouseDown()
    {
        if (PetAttributes.SleepMode == false)
        {
            PetAttributes.SleepMode = true;
        }
        else
        {
            PetAttributes.SleepMode = false;
        }
    }
}