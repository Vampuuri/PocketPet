using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameInventoryScript : MonoBehaviour
{
    private List<Item> itemList = new List<Item>();
    public int moneyAmount;

    public void Start()
    {
        moneyAmount = 0;
    }

    public void Update()
    {

    }

    public void AddItem (Item item)
    {
        itemList.Add(item);
        Debug.Log(itemList.Count + "i got an item");
    }

    public void AddMoney(int amount)
    {
        moneyAmount += amount;
        Debug.Log(moneyAmount);
    }


    public void RemoveItem(Item.ItemType type)
    {
        itemList.Remove(itemList.Find(item => item.itemType == type));
    }

    public int GetAmountOfItemType(Item.ItemType type)
    {
        return itemList.Where(Item => Item.itemType==type).ToList().Count();
    }
}
