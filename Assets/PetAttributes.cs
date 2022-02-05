using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PetAttributes : MonoBehaviour
{

    public static PetAttributes instance;
    public static GameObject attributes;
    public static List<GameObject> attributesList = new List<GameObject>();

    //Attributes
    public float minHunger, minHygiene, minEnergy;
    public static float hunger, hygiene, energy;

    public Text HungerTxt;

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
    }

    void Update()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (HungerTxt != null) 
            HungerTxt.text = "HUNGER : " + hunger.ToString("F0");
        if (hunger > minHunger)
        {
            hunger -= 1 * Time.deltaTime;
            if(hunger <= minHunger)
            {
                //mitä tapahtuu kun nälkä nolla?
                Die();
            }
        }

    }
    
    void OnSceneLoaded (Scene gamescreen, LoadSceneMode mode)
    {
        GameObject hungerTextObject = GameObject.Find("Hunger");
        if (hungerTextObject != null)
        {
            HungerTxt = hungerTextObject.GetComponent<Text>();
        }
    }

    void Die()
    {
        print("you died of hunger");
    }
}





