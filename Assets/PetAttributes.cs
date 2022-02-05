using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PetAttributes : MonoBehaviour
{

    public static PetAttributes instance;
    public static GameObject attributes;
    public static List<GameObject> attributesList = new List<GameObject>();

    //Attributes
    public float minHunger, minHygiene, minEnergy;
    public static float hunger, hygiene, energy;

    public float HungerSpeed;
    public float HygieneSpeed;
    public float EnergySpeed;

    public Text HungerTxt;
    public Text HygieneTxt;
    public Text EnergyTxt;

    private void Awake()
    {
        Time.timeScale = 1;
        attributes = GameObject.Find("EssinManager");


        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            attributesList.AddRange(GameObject.FindGameObjectsWithTag("attributes"));
            DontDestroyOnLoad(attributes);
        }
    }

    private void Start()
    {
        hunger = 100;
        hygiene = 100;
        energy = 100;
        HungerSpeed = 2f;
        HygieneSpeed = 1f;
        EnergySpeed = 0.5f;
    }

    void Update()
    {
        //n�lk�
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (HungerTxt != null) 
            HungerTxt.text = "HUNGER : " + hunger.ToString("F0");
        if (hunger > minHunger)
        {
            hunger -= HungerSpeed * Time.deltaTime;
            if(hunger <= minHunger)
            {
                //mit� tapahtuu kun n�lk� nolla?
                Die();
            }
        }

        //hygienia
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (HygieneTxt != null)
            HygieneTxt.text = "HYGIENE : " + hygiene.ToString("F0");
        if (hygiene > minHygiene)
        {
            hygiene -= HygieneSpeed * Time.deltaTime;
            if (hygiene <= minHygiene)
            {
                //mit� tapahtuu kun hygienia nolla?
                Die();
            }
        }

        //energia
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (EnergyTxt != null)
            EnergyTxt.text = "ENERGY : " + energy.ToString("F0");
        if (energy > minEnergy)
        {
            energy -= EnergySpeed * Time.deltaTime;
            if (energy <= minEnergy)
            {
                //mit� tapahtuu kun hygienia nolla?
                Die();
            }
        }
    }
    
    void OnSceneLoaded (Scene gamescreen, LoadSceneMode mode)
    {
        //n�lk�
        GameObject hungerTextObject = GameObject.Find("Hunger");
        if (hungerTextObject != null)
        {
            HungerTxt = hungerTextObject.GetComponent<Text>();
        }
        //hygienia
        GameObject hygieneTextObject = GameObject.Find("Hygiene");
        if (hygieneTextObject != null)
        {
            HygieneTxt = hygieneTextObject.GetComponent<Text>();
        }
        //energia
        GameObject energyTextObject = GameObject.Find("Energy");
        if (energyTextObject != null)
        {
            EnergyTxt = energyTextObject.GetComponent<Text>();
        }
    }

    void Die()
    {
        print("you died of hunger");
    }
}





