using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToContinue : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("test");
            EventManager.Instance.onSecondStageStart?.Invoke();
        }
    }
}
