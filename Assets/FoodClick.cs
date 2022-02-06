using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodClick : MonoBehaviour

{
    public GameObject PetHungerObject;

    private PetAttributes PetHunger;


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
        Debug.Log("The hunger is " + PetAttributes.hunger);
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked Food! Yum!");
        PetAttributes.hunger += 20;
    }
}

