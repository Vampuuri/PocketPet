using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoneyScript : MonoBehaviour
{
    Rigidbody2D RB;
    public MoneyGenerator moneyGenerator;
    public int coinValue = 1;

    private GameInventoryScript inventory;

    private List<Item> itemList;

    private void Awake()
    {
        inventory = new GameInventoryScript();
    }

    private void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.left * moneyGenerator.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextLine"))
        {
            moneyGenerator.GenerateNextMoneyWithGap();
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            CoinCounter.instance.ChangeCoinCount(coinValue);
            Destroy(this.gameObject);

            //jos t�st� lis�� niin menee kokoajan takas ykk�seen m��r�?
            inventory.AddItem(new Item { itemType = Item.ItemType.Coins, amount = coinValue });
        }
    }
}
