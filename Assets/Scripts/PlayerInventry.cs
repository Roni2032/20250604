using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventry : MonoBehaviour
{
    List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        int maxStack = ItemManager.instance.GetMaxStack();
        Item itemStack = items.Find(x => x.GetID() == item.GetID());
       
        if (itemStack != null)
        {
            int overStack = itemStack.AddStack(item.GetStack());
            if(overStack > 0)
            {
                Item item1 = new Item(item.GetID(), overStack);
                items.Add(item1);
            }
        }
        else
        {
            items.Add(item);
        }
        Debug.Log("アイテムを追加:" + ItemManager.instance.GetItemDisplayName(item.GetID()) + " x" + item.GetStack());
    }
    public void RemoveItem(string id, int count)
    {
        Item itemStack = items.Find(x => x.GetID() == id);
        if (itemStack != null)
        {
            Debug.Log("アイテムを削除:" + ItemManager.instance.GetItemDisplayName(id) + " x" + count);
            itemStack.ReduceStack(count);
            if (itemStack.GetStack() <= 0)
            {
                items.Remove(itemStack);
            }
        }
    }

    public void CraftItem(string id)
    {
        if(!ItemManager.instance.IsItemExist(id))
        {
            return;
        }
        List<ItemRecipeData> recipe = ItemManager.instance.GetRecipe(id);
        int craftCount = ItemManager.instance.GetCraftCount(id);
        if (!ItemManager.instance.CheckCraftItem(recipe, items))
        {
            return;
        }
        foreach (var item in recipe)
        {
            Item itemStack = items.Find(x => x.GetID() == item.itemID);
            if (itemStack != null && itemStack.GetStack() >= item.count)
            {
                RemoveItem(item.itemID, item.count);
            }
        }
        Item craftItem = new Item(id, craftCount);
        AddItem(craftItem);
    }
    
    void Start()
    {
        
    }

    public void OnCraft(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // ここは実際のアイテムIDに置き換えてください
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
