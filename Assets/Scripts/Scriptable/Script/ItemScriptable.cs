using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemScriptable", menuName = "Scriptable Objects/ItemScriptable")]
public class ItemScriptable : ScriptableObject
{
    [SerializeField]
    List<ItemScriptableDate> dates = new List<ItemScriptableDate>();

    public ItemScriptableDate GetDate(string id)
    {
        return dates.Find(x => x.itemID == id);
    }
}

[Serializable]
public class ItemScriptableDate
{
    public string itemID;
    public string displayName;
    public string itemClass;

    public GameObject prefub;

    public int craftCount;
    public List<ItemRecipeData> recipeID;
    
}

[Serializable]
public class ItemRecipeData
{
    public string itemID;
    public int count;
}
