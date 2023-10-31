using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    instance = singletonObject.AddComponent<T>();
                }
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(this.gameObject);
            Debug.Log("if");
        }
        else
        {
            Debug.Log("else");
            Destroy(gameObject);
        }
    }
    protected virtual void OnApplicationQuit()
    {
        instance = null;
        Destroy(gameObject);    
        Debug.Log("quit");
    }
}

// public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour 
// {
//     public static T Instance { get; private set; }
//     protected virtual void Awake() => Instance = this as T;

//     protected virtual void OnApplicationQuit()
//     {
//         Instance = null;
//         Destroy(gameObject);    
//     }
// }

// public abstract class SingletonPersistent<T> : Singleton<T> where T : MonoBehaviour
// {
//     protected override void Awake()
//     {
//         if (Instance != null) Destroy(gameObject);
//         DontDestroyOnLoad(gameObject);
//         base.Awake();
//     }
// }

