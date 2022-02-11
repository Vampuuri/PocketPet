using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameInventoryScript
{
    private List<Item> itemList;

    public void Update()
    {
    }


    public GameInventoryScript()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.Coins, amount =+ 1 });
    }

    public void AddItem (Item item)
    {
        itemList.Add(item);
        Debug.Log(itemList.Count + "i got an item");
    }
}
