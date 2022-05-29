using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanClick : MonoBehaviour

{
    public GameObject PetHygieneObject;

    private PetAttributes PetHygiene;


    void HungerSource()
    {
        PetHygieneObject = GameObject.Find("EssinManager");

    }

    void Awake()
    {
        PetHygiene = GetComponent<PetAttributes>();
    }

    private void Start()
    {

    }

    private void OnMouseDown()
    {
        if (PetAttributes.SleepMode == false)
        PetAttributes.hygiene += 100;
        Debug.Log("hygiene raised");
    }
}

