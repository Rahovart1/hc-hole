using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : Singleton<EventManager>
{
    public UnityEvent<CollectibleType> onCollect;
    public UnityEvent onLevelUp;
}
