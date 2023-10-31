using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
[CreateAssetMenu(fileName = "Pop-Up Data", menuName = "Datas/PopupData", order = 0)]
public class PopupData : ScriptableObject
{
    public float disappearTime;
    public float smooth;
    public float moveDistance;
}
