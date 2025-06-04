using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    [SerializeField]
    [Header("テスト用のアイテムID")]
    string testID = "test_item";

    [SerializeField]
    [Header("アイテムのマスターデータ")]
    ItemScriptable itemScriptable;
    [SerializeField]
    [Header("アイテムの最大スタック数")]
    int maxStack;

    private void Awake()
    {
        instance = this;
    }
    public bool IsItemExist(string id)
    {
        if(itemScriptable.GetDate(id) == null)
        {
            Debug.LogError("未登録のアイテムIDです : " + id);
            return false;
        }
        return true;
    }
    public Item CreateItem(string id, int amount = 1)
    {
        if (!IsItemExist(id))
        {
            return null;
        }
        Type itemType = Type.GetType(itemScriptable.GetDate(id).itemClass);

        Item item = (Item)Activator.CreateInstance(itemType, id, amount);

        return item;
    }
    public T CreateItem<T>(string id, int amount = 1)
    {
        if (!IsItemExist(id))
        {
            return default(T);
        }
        Type itemType = Type.GetType(itemScriptable.GetDate(id).itemClass);

        T item = (T)Activator.CreateInstance(itemType, id, amount);

        return item;
    }
    public int GetMaxStack()
    {
        return maxStack;
    }
    public void SpawnItemObject(string id,Vector3 position)
    {
        Instantiate(GetItemPrefab(id), Vector3.zero, Quaternion.identity);
    }
    public bool CheckCraftItem(string id,List<Item> items)
    {
        List<ItemRecipeData> recipe = GetRecipe(id);
        
        return CheckCraftItem(recipe,items);
    }
    public bool CheckCraftItem(List<ItemRecipeData> recipe, List<Item> items)
    {
        bool isCraftable = true;
        foreach (var item in recipe)
        {
            Item itemData = items.Find(x => x.GetID() == item.itemID);
            if (itemData == null || itemData.GetStack() < item.count)
            {
                isCraftable = false;
                break;
            }
        }
        if (!isCraftable)
        {
            Debug.Log("クラフトできませんでした。必要なアイテムが足りません。");
            return false;
        }
        return true;
    }
    public ItemScriptableDate GetItemData(string id)
    {
        return itemScriptable.GetDate(id);
    }
    public string GetItemDisplayName(string id)
    {
        string displayName = GetItemData(id).displayName;
        if(displayName == "")
        {
            displayName = id;
        }
        return displayName;
    }
    public List<ItemRecipeData> GetRecipe(string id)
    {
        return GetItemData(id).recipeID;
    }
    public int GetCraftCount(string id)
    {
        return GetItemData(id).craftCount;
    }
    public GameObject GetItemPrefab(string id)
    {
        return GetItemData(id).prefub;
    }
}
