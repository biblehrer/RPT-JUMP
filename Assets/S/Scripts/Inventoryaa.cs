using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItemList
{
    public InventoryItem[] items;

    public InventoryItemList(InventoryItem[] items)
    {
        this.items = items;
    }

    [Serializable]
    public class InventoryItem
    {
        public string itemName;
        public int quantity;

        public InventoryItem(string itemName, int quantity)
        {
            this.itemName = itemName;
            this.quantity = quantity;
        }
    }
}
