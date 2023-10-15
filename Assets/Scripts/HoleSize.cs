using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSize : MonoBehaviour
{
    [SerializeField] private float _currentScale;
    [SerializeField] private float _smooth;
    private float _targetScale;
    private void Start()
    {
        _currentScale = 1;    
        _targetScale = _currentScale;   
    }
    public void IncreaseSize(float scale)
    {
        _targetScale += scale;
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
