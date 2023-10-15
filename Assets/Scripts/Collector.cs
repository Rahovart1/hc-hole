using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Collectible collectible))
        {
            EventManager.Instance.onCollect?.Invoke(collectible.GetCollectibleType());
            Destroy(other.gameObject);
        }
    }
}
