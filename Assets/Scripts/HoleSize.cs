using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSize : MonoBehaviour
{
    [SerializeField] private float _currentScale;
    private void Start()
    {
        _currentScale = 1;    
    }
    public void IncreaseSize(float scale)
    {
        _currentScale += scale;
        transform.localScale = new(_currentScale, _currentScale, _currentScale);
    }
}
