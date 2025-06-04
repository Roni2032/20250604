using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    List<string> tags = new List<string>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddTag(string tag)
    {
        tags.Add(tag);
    }
    public bool FindTag(string tag)
    {
        return tags.Find(x => x == tag) != null;
    }
    public virtual void Use(GameObject player) { }
}
