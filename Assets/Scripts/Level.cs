using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int _currentXp;
    [SerializeField] private int _xpToLevelUp;
    [SerializeField] private LevelBar _levelBar;
    private void Start()
    {
        CalculatePercentage();    
    }
    public void GainXp(int xp)
    {
        _currentXp += xp;

        if (_currentXp >= _xpToLevelUp)
        {
            EventManager.Instance.onLevelUp?.Invoke();
            _xpToLevelUp += 40;
            _currentXp = 0;
        }

        CalculatePercentage();
    }
    private void CalculatePercentage()
    {
        _levelBar.UpdateUI((float)_currentXp / _xpToLevelUp);
    }
}