using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControlScript : MonoBehaviour
{
    //is x sold is unused bc its for items purchasable once
    int moneyAmount;
    int isHaySold;
    int hayPrice;    
    int meatPrice;   
    int fishPrice;
    int carrotPrice;
    int applePrice;
    int bonePrice;
    int candyPrice;

    public Text MoneyAmountText;

    public Text hayPriceText;
    public Button buyHayButton;

    public Text meatPriceText;
    public Button buyMeatButton;

    public Text fishPriceText;
    public Button buyFishButton;

    public Text carrotPriceText;
    public Button buyCarrotButton;

    public Text applePriceText;
    public Button buyAppleButton;

    public Text bonePriceText;
    public Button buyBoneButton;

    public Text candyPriceText;
    public Button buyCandyButton;

    public static float minMoney;

    public GameInventoryScript inventory;

    private void Start()
    {
        inventory = GameObject.Find("EssinManager").GetComponent<GameInventoryScript>();
        minMoney = 0;

        moneyAmount = inventory.moneyAmount;
        hayPrice = 2;
        meatPrice = 2;
        fishPrice = 2;
        carrotPrice = 2;
        applePrice = 2;
        bonePrice = 2;
        candyPrice = 2;

        //koodi kertaostettaville esineille
        if (moneyAmount >= 1 && isHaySold == 0)
            buyHayButton.interactable = true;
        else
            buyHayButton.interactable = false;
    }

    public void Update()
    {
        MoneyAmountText.text = "Money: " + moneyAmount.ToString();
        hayPriceText.text = "HAY " + hayPrice.ToString() + " coins";
        meatPriceText.text = "MEAT " + hayPrice.ToString() + " coins";
        fishPriceText.text = "FISH " + hayPrice.ToString() + " coins";
        carrotPriceText.text = "FISH " + hayPrice.ToString() + " coins";
        applePriceText.text = "APPLE " + hayPrice.ToString() + " coins";
        bonePriceText.text = "BONE " + hayPrice.ToString() + " coins";
        candyPriceText.text = "CANDY " + hayPrice.ToString() + " coins";
    }

    public void buyHay()
    {
        if (moneyAmount - hayPrice >= minMoney)
        {
            moneyAmount -= hayPrice;
            inventory.AddMoney(-hayPrice);
            inventory.AddItem(new Item(Item.ItemType.Hay,1));
            Debug.Log("bought!");
        }
        else
            Debug.Log("you cant afford this!");
    }

    public void buyMeat()
    {
        if (moneyAmount - meatPrice >= minMoney)
        {
            moneyAmount -= meatPrice;
            inventory.AddMoney(-meatPrice);
            inventory.AddItem(new Item(Item.ItemType.Meat, 1));
            Debug.Log("bought!");
        }
        else
            Debug.Log("you cant afford this!");
    }

    public void buyFish()
    {
        if (moneyAmount - fishPrice >= minMoney)
        {
            moneyAmount -= fishPrice;
            inventory.AddMoney(-fishPrice);
            inventory.AddItem(new Item(Item.ItemType.Fish, 1));
            Debug.Log("bought!");
        }
        else
            Debug.Log("you cant afford this!");
    }
    public void buyCarrot()
    {
        if (moneyAmount - carrotPrice >= minMoney)
        {
            moneyAmount -= carrotPrice;
            inventory.AddMoney(-carrotPrice);
            inventory.AddItem(new Item(Item.ItemType.Carrot, 1));
            Debug.Log("bought!");
        }
        else
            Debug.Log("you cant afford this!");
    }
    public void buyApple()
    {
        if (moneyAmount - applePrice >= minMoney)
        {
            moneyAmount -= applePrice;
            inventory.AddMoney(-applePrice);
            inventory.AddItem(new Item(Item.ItemType.Apple, 1));
            Debug.Log("bought!");
        }
        else
            Debug.Log("you cant afford this!");
    }
    public void buyBone()
    {
        if (moneyAmount - bonePrice >= minMoney)
        {
            moneyAmount -= bonePrice;
            inventory.AddMoney(-bonePrice);
            inventory.AddItem(new Item(Item.ItemType.Bone, 1));
            Debug.Log("bought!");
        }
        else
            Debug.Log("you cant afford this!");
    }
    public void buyCandy()
    {
        if (moneyAmount - candyPrice >= minMoney)
        {
            moneyAmount -= candyPrice;
            inventory.AddMoney(-candyPrice);
            inventory.AddItem(new Item(Item.ItemType.Candy, 1));
            Debug.Log("bought!");
        }
        else
            Debug.Log("you cant afford this!");
    }

    public void exitShop()
    {
        PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
        SceneManager.LoadScene("GameScene");
    }
}
