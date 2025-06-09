using UnityEngine;

public class ObjectEntity : Entity
{
    
    void Start()
    {
       Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Initialize()
    {
        AddTag("object");
    }
    public override void Use(GameObject player)
    {
        Debug.Log("åöë¢ï®Ç…êGÇÍÇ‹ÇµÇΩ");
    }
}
