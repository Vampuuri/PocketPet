using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodClick : MonoBehaviour

{
    public GameObject PetHungerObject;

    private PetAttributes PetHunger;
    private PetAttributes SleepMode;

    public GameInventoryScript inventory;


    void Start()
    {
        inventory = GameObject.Find("EssinManager").GetComponent<GameInventoryScript>();
    }

    void HungerSource()
    {
        PetHungerObject = GameObject.Find("EssinManager");

    }

    void Awake()
    {
        PetHunger = GetComponent<PetAttributes>();
    }

    private void OnMouseDown()
    {
        if (PetAttributes.SleepMode == false)
        {
            if (inventory.GetAmountOfItemType(Item.ItemType.Hay) > 0)
            {
                PetAttributes.hunger += 20;
                inventory.RemoveItem(Item.ItemType.Hay);
            }
        }
    }
}

