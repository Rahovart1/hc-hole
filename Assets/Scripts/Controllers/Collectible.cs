using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour, ICollectible
{
    [SerializeField] private CollectibleType type;

    public void Collect()
    {
        EventManager.Instance.onCollect?.Invoke(type);
        Destroy(gameObject);
    }
}
