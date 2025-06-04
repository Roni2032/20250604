using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    string itemID;

    int stack = 1;
    
    public Item Copy()
    {
        Item item = ItemManager.instance.CreateItem(itemID, stack);
        return item;
    }
    public Item(string id,int amount = 1)
    {
        Initialize(id, amount);
    }
    public virtual void Initialize(string id,int amount)
    {
        if(ItemManager.instance.IsItemExist(id))
        {
            itemID = id;
            stack = amount;
        }
    }
    public string GetID()
    {
        return itemID;
    }
    public int AddStack(int amount)
    {
        stack += amount;
        int maxStack = ItemManager.instance.GetMaxStack();
        if (stack > maxStack)
        {
            int overStack = stack - maxStack;
            stack = maxStack;

            return overStack;
        }
        return 0;
    }
    public void ReduceStack(int amount)
    {
        stack -= amount;
        if (stack < 0)
        {
            stack = 0;
        }
    }
    public int GetStack()
    {
        return stack;
    }
    public virtual int GetMaxStack()
    {
        return ItemManager.instance.GetMaxStack();
    }
}
