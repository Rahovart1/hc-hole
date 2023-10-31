using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class XpPopupController : MonoBehaviour
{
    [SerializeField] private GameObject _xpPrefab;

    private void OnEnable()
    {
        EventManager.Instance.onCollect.AddListener(Collect);    
    }
    private void OnDisable()
    {
        EventManager.Instance.onCollect.RemoveListener(Collect);    
    }
    public void Collect(CollectibleType type)
    {
        int value = type switch
        {
            CollectibleType.small => 5,
            CollectibleType.medium => 8,
            CollectibleType.large => 15,
        };

        GameObject obj = Instantiate(_xpPrefab, transform.position, Quaternion.identity, transform);
        //obj.GetComponent<TextMeshProUGUI>().text = $"+{value}";
    }
}
