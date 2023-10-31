using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvironmentController : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    private void OnEnable()
    {
        EventManager.Instance.onFirstStageStart.AddListener(LoadObjects);    
    }
    private void OnDisable()
    {
        EventManager.Instance.onFirstStageStart.RemoveListener(LoadObjects);
    }
    public void LoadObjects()
    {
        Instantiate(_prefab, transform.position, Quaternion.identity, transform);
    }

}
