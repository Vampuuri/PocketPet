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
        Debug.Log("The hygiene is " + PetAttributes.hygiene);
    }

    private void OnMouseDown()
    {
        Debug.Log("All Clean!");
        PetAttributes.hygiene += 100;
    }
}

