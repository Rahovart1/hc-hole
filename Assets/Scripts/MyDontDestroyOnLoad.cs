using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDontDestroyOnLoad : MonoBehaviour
{
    private void Awake() => DontDestroyOnLoad(gameObject);
    private void OnApplicationQuit()
    {
        Destroy(this.gameObject);
    }
}
