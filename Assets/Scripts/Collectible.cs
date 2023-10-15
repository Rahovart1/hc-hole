using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private CollectibleType type;

    public CollectibleType GetCollectibleType() => type;
}
