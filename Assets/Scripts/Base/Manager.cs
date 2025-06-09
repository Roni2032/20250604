using System;
using UnityEngine;

public abstract class Manager<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<T>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }
    /// <summary>
    /// èâä˙âª
    /// </summary>
    public virtual void Init()
    {

    }
}
