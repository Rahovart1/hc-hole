using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : Singleton<EventManager>
{
    public UnityEvent<CollectibleType> onCollect = new UnityEvent<CollectibleType>();
    
    public UnityEvent onLevelUp = new UnityEvent();

    public UnityEvent onFirstStageStart = new UnityEvent();
    public UnityEvent onFirstStageEnd = new UnityEvent();
    public UnityEvent onSecondStageStart = new UnityEvent();
    public UnityEvent onSecondStageEnd = new UnityEvent();
    
}
