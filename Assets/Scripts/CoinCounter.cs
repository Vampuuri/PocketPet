using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    public Text CoinCount;
    int coins;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        
    }
    
    public void ChangeCoinCount(int coinValue)
    {
        coins += coinValue;
        CoinCount.text = "Coins: " + coins.ToString();
    }
}

 

