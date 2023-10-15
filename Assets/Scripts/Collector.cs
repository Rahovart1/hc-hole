using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ICollectable collectable = other.GetComponent<ICollectable>();

        if (collectable != null)
        {
            var value = collectable.type switch
            {
                CollectableType.small => CollectableType.small,
                CollectableType.medium => CollectableType.medium,
                CollectableType.large => CollectableType.large,
                _ => throw new System.NotImplementedException(),
            };
            Debug.Log(value.ToString()+""+"Test");
            Destroy(other.gameObject);
            EventManager.Instance.onCollect?.Invoke();
        }
    }
}
