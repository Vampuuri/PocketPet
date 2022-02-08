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
    public static float minHunger, minHygiene, minEnergy, minFun;
    public static float maxHunger, maxHygiene, maxEnergy, maxFun;
    public static float hunger, hygiene, energy, fun;


    public static float HungerSpeed;
    public static float HygieneSpeed;
    public static float EnergySpeed;
    public static float SleepRegain;
    public static float GameEnergyLoss;
    public static float FunSpeed;

    public Text HungerTxt;
    public Text HygieneTxt;
    public Text EnergyTxt;
    public Text FunTxt;

    public static bool SleepMode = false;

    public static Button GameButton;

    public Slider hungerbar;
    public Slider hygienebar;
    public Slider energybar;
    public Slider funbar;

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
        hungerbar = GameObject.Find("HungerBar").GetComponent<Slider>();
        hygienebar = GameObject.Find("HygieneBar").GetComponent<Slider>();
        energybar = GameObject.Find("EnergyBar").GetComponent<Slider>();
        funbar = GameObject.Find("FunBar").GetComponent<Slider>();
    }

    private void Start()
    {
        hunger = 100;
        hygiene = 100;
        energy = 100;
        fun = 100;
        FunSpeed = 2f;
        HungerSpeed = 1.5f;
        HygieneSpeed = 1f;
        EnergySpeed = 0.5f;
        SleepRegain = 2f;
        GameEnergyLoss = 20;
        maxFun = 100;
        maxHunger = 100;
        maxHygiene = 100;
        maxEnergy = 100;
    }

    void Update()
    {
        //nälkä
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (HungerTxt != null)
            HungerTxt.text = "HUNGER: " + hunger.ToString("F0");
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
            SceneManager.sceneLoaded += OnSceneLoaded;
            if (hungerbar != null)
                hungerbar.value = hunger;
        }

        {
            //hygienia
            SceneManager.sceneLoaded += OnSceneLoaded;
            if (HygieneTxt != null)
                HygieneTxt.text = "HYGIENE: " + hygiene.ToString("F0");
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
            hygienebar.value = hygiene;
        }

        //energia
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (EnergyTxt != null)
            EnergyTxt.text = "ENERGY: " + energy.ToString("F0");
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
            if (SleepMode == true)
            {
                energy += SleepRegain * Time.deltaTime;
                if (energy >= maxEnergy)
                {
                    SleepMode = false;
                }
            }
            energybar.value = energy;

        }
        //hupi
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (FunTxt != null)
            FunTxt.text = "FUN: " + fun.ToString("F0");
        if (fun > minFun)
        {
            fun -= FunSpeed * Time.deltaTime;
            if (fun <= minFun)
            {
                //mitä tapahtuu kun nälkä nolla?
                Die();
            }
            if (fun >= maxFun)
            {
                //mitä tapahtuu kun nälkä maxhunger?
                FullFun();
            }
            funbar.value = fun;

        }

        void OnSceneLoaded(Scene gamescreen, LoadSceneMode mode)
        {
            //nälkä
            GameObject hungerTextObject = GameObject.Find("Hunger");
            if (hungerTextObject != null)
            {
                HungerTxt = hungerTextObject.GetComponent<Text>();
            }
            //koitin tohon Hungerbar monta eri tapaa kirjottaa asian mutta ei auta.
            GameObject HungerBarSlider = GameObject.Find("HungerBar");
            if (HungerBarSlider != null)
            {
                hungerbar = HungerBarSlider.GetComponent<Slider>();
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
            //hupi
            GameObject funTextObject = GameObject.Find("Fun");
            if (funTextObject != null)
            {
                FunTxt = funTextObject.GetComponent<Text>();
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
        void FullFun()
        {
            fun = 100;
        }
    }
}






