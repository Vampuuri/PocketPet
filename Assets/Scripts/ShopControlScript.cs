using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControlScript : MonoBehaviour
{
    int moneyAmount;
    int isHaySold;
    int hayPrice;

    public Text MoneyAmountText;

    
    public Text hayPriceText;

    public Button buyHayButton;

    public static float minMoney;

    public GameInventoryScript inventory;

    private void Start()
    {
        inventory = GameObject.Find("EssinManager").GetComponent<GameInventoryScript>();
        minMoney = 0;

        moneyAmount = inventory.moneyAmount;
        hayPrice = 2;

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

    public void exitShop()
    {
        PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
        SceneManager.LoadScene("GameScene");
    }
}
