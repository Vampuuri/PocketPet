using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetAttributes : MonoBehaviour
{

    //Attributes
    public float minHunger, minHygiene, minEnergy;
    public static float hunger, hygiene, energy;

    public Text HungerTxt;

    private void Start()
    {
        hunger = 100;
        hygiene = 100;
        energy = 100;
    }

    void Update()
    {
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
    
    void Die()
    {
        print("you died of hunger");
    }
}





