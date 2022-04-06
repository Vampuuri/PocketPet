using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Coins,
        Hay,
    }

    public ItemType itemType;
    public int amount;

    public Item(ItemType IT, int initialAmount)
    {
        itemType = IT;
        amount = initialAmount;
    }
}

