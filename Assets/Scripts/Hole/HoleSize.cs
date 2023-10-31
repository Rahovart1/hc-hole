using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSize : MonoBehaviour
{
    [SerializeField] private float _currentScale;
    [SerializeField] private float _smooth;
    [SerializeField] private float _increaseSize;

    private float _targetScale;
    private void Start()
    {
        _currentScale = 1;    
        _targetScale = _currentScale;   
    }
    private void OnEnable()
    {
        EventManager.Instance.onLevelUp.AddListener(IncreaseSize);
    }
    private void OnDisable()
    {
        EventManager.Instance.onLevelUp.RemoveListener(IncreaseSize);
    }
    public void IncreaseSize()
    {
        _targetScale += _increaseSize;
        StartCoroutine(ChangeSize());
    }
    private IEnumerator ChangeSize()
    {
        while (_targetScale - _currentScale > 0.01f)
        {
            _currentScale = Mathf.Lerp(_currentScale, _targetScale, _smooth);
            transform.localScale = new(_currentScale, _currentScale, _currentScale);
            yield return null;
        }
        _currentScale = _targetScale;
        transform.localScale = new(_currentScale, _currentScale, _currentScale);
    }
}
