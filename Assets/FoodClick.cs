using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodClick : MonoBehaviour

{
    public GameObject PetHungerObject;

    private PetAttributes PetHunger;
    private PetAttributes SleepMode;


    void HungerSource()
    {
        PetHungerObject = GameObject.Find("EssinManager");

    }

    void Awake()
    {
        PetHunger = GetComponent<PetAttributes>();
    }

    private void Start()
    {

    }

    private void OnMouseDown()
    {
        if (PetAttributes.SleepMode == false)
        {
            PetAttributes.hunger += 20;
        }
    }
}

