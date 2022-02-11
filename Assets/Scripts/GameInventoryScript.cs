using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameInventoryScript
{
    private List<Item> itemList;

    public GameInventoryScript()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.Coins, amount = 1 });

        Debug.Log(itemList.Count);
    }

    public void AddItem (Item item)
    {
        itemList.Add(item);
    }
}
