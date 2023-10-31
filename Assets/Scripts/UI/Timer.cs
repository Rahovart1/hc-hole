using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;
    [SerializeField] private Image _bar;
    [SerializeField] private float _startTime;
    private float _currentTime;
    private bool _isRunning;
    private Color _barColor;

    private void OnEnable()
    {
        StartTimer();
        _barColor = _bar.color;  
    }
    private void FixedUpdate() 
    {
        if (_isRunning && _currentTime > 0f)
        {
            _currentTime -= Time.fixedDeltaTime;
            UpdateUI();
        }
        else
        {
            StopTimer();
            EventManager.Instance.onFirstStageEnd?.Invoke();
            gameObject.SetActive(false);
        }
    }
    private void UpdateUI()
    {
        _counterText.SetText(_currentTime.ToString("0"));
        var amount = _currentTime / _startTime;
        _bar.fillAmount = amount;
        _barColor.a = amount;
        _bar.color = _barColor;
    }
    public void StartTimer()
    {
        _currentTime = _startTime;
        _isRunning = true;
    }

    public void StopTimer()
    {
        _currentTime = 0f;
        _isRunning = false;
        UpdateUI();
    }
}
