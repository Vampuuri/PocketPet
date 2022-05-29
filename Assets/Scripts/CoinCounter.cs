using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    public Text CoinCount;
    public static int coins;


    private GameInventoryScript inventory;
    private PlayerScript playerScript;

    private List<Item> itemList;

    private GameManager gameManager;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    private void Update()
    {
        CoinCount.text = "Coins: " + playerScript.coinAmount.ToString();
    }

    public void ChangeCoinCount(int coinValue)
    {
        coins += coinValue;
    }
}

 

