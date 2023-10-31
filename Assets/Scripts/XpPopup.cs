using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpPopup : MonoBehaviour
{
    [SerializeField] private PopupData _popupData;
    private Vector3 _pos;

    private void Start()
    {
        Destroy(gameObject, _popupData.disappearTime);
        _pos = new(0, _popupData.moveDistance, 0);    
    }
    private void FixedUpdate()
    {   
        transform.localPosition = Vector3.Lerp(transform.localPosition, _pos, _popupData.smooth * Time.deltaTime);
    }
}
