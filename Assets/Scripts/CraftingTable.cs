using UnityEngine;

public class CraftingTable : ObjectEntity
{
    public string craftItem = "stone_and_stick";
    public override void Use(GameObject player)
    {
        PlayerInventry inventry = player.GetComponent<PlayerInventry>();
        inventry.CraftItem(craftItem);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialize();
        AddTag("crafting_table");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
