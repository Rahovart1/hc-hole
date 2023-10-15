using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _duration;
    private float _targetValue;
    private bool _isUpdating;
    private void Start()
    {
        _isUpdating = false;
        _targetValue = 0;    
    }
    public void UpdateUI(float value)
    {
        //StopCoroutine(SmoothUpdate(value));
        _targetValue = value;

        if (!_isUpdating)
        {
            StartCoroutine(SmoothUpdate());
        }
    } 
    private IEnumerator SmoothUpdate()
    {
        _isUpdating = true;
        float elapsedTime = 0f;
        float startValue = _image.fillAmount;

        while (elapsedTime < _duration)
        {
            _image.fillAmount = Mathf.Lerp(startValue, _targetValue, elapsedTime / _duration);
            elapsedTime += Time.deltaTime;
            yield return null; 
        }
        
        _image.fillAmount = _targetValue;
        _targetValue = 0f;
        _isUpdating = false;
    }
}

