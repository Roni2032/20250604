using UnityEngine;
using UnityEngine.InputSystem;

public class AreaIntaract : MonoBehaviour
{
    GameObject player;
    PlayerInventry playerInventory;

    Entity hittingEntity;
    void Start()
    {
        player = transform.parent.gameObject;
        playerInventory = transform.parent.GetComponent<PlayerInventry>();
    }

    public void OnIntract(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (hittingEntity != null)
            {
                hittingEntity.Use(player);
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        Entity entity = obj.GetComponent<Entity>();
        if (entity != null)
        {
            hittingEntity = entity;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        GameObject obj = other.gameObject;
        Entity entity = obj.GetComponent<Entity>();
        if (entity != null && hittingEntity.gameObject == obj)
        {
            Debug.Log("Entity‚ª—£‚ê‚Ü‚µ‚½ ");
            hittingEntity = null;
        }
    }
}
