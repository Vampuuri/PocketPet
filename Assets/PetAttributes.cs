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
    public float maxHunger, maxHygiene, maxEnergy;
    public static float hunger, hygiene, energy;


    public float HungerSpeed;
    public float HygieneSpeed;
    public float EnergySpeed;
    public float SleepRegain;
    public static float GameEnergyLoss;

    public Text HungerTxt;
    public Text HygieneTxt;
    public Text EnergyTxt;

    public static bool SleepMode = false;

    public static Button GameButton;


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
        HungerSpeed = 1.5f;
        HygieneSpeed = 1f;
        EnergySpeed = 0.5f;
        SleepRegain = 2f;
        GameEnergyLoss = 20;
        maxHunger = 100;
        maxHygiene = 100;
        maxEnergy = 100;
    }

    void Update()
    {
        //nälkä
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (HungerTxt != null)
            HungerTxt.text = "HUNGER : " + hunger.ToString("F0");
        if (hunger > minHunger)
        {
            hunger -= HungerSpeed * Time.deltaTime;
            if (hunger <= minHunger)
            {
                //mitä tapahtuu kun nälkä nolla?
                Die();
            }
            if (hunger >= maxHunger)
            {
                //mitä tapahtuu kun nälkä maxhunger?
                FullHunger();
            }

        }

        {
            //hygienia
            SceneManager.sceneLoaded += OnSceneLoaded;
            if (HygieneTxt != null)
                HygieneTxt.text = "HYGIENE : " + hygiene.ToString("F0");
            if (hygiene > minHygiene)
            {
                hygiene -= HygieneSpeed * Time.deltaTime;
                if (hygiene <= minHygiene)
                {
                    //mitä tapahtuu kun hygienia nolla?
                    Die();
                }
                if (hygiene >= maxHygiene)
                {
                    //mitä tapahtuu kun nälkä maxhygiene?
                    FullHygiene();
                }
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
                //mitä tapahtuu kun nolla?
                Die();
            }
            if (energy >= maxEnergy)
            {
                //mitä tapahtuu kun maxenergy?
                FullEnergy();
            }
        }
    }

void OnSceneLoaded(Scene gamescreen, LoadSceneMode mode)
    {
        //nälkä
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

    void FullHunger()
    {
        hunger = 100;
    }
    void FullHygiene()
    {
        hygiene = 100;
    }
    void FullEnergy()
    {
        energy = 100;
    }
}





