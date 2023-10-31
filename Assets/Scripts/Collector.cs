using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collector : MonoBehaviour
{
    public int[] collectibles;

    private void Start()
    {
       collectibles = new int[Enum.GetNames(typeof(CollectibleType)).Length];
    }
    private void OnEnable()
    {
        EventManager.Instance.onCollect.AddListener(Collect);    
    }
    private void OnDisable()
    {
        EventManager.Instance.onCollect.RemoveListener(Collect);    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ICollectible collectible))
        {
            collectible.Collect();
        }
    }

    public void Collect(CollectibleType type)
    {
        collectibles[(int)type] += 1;
    }
}
