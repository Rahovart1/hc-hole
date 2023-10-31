using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int _currentXp;
    [SerializeField] private int _xpToLevelUp;
    [SerializeField] private LevelBar _levelBar;
    private void Start()
    {
        CalculatePercentage();    
    }
    private void OnEnable()
    {
        EventManager.Instance.onCollect.AddListener(GainXp);
    }
    private void OnDisable()
    {
        EventManager.Instance.onCollect.RemoveListener(GainXp);
    }
    public void GainXp(CollectibleType type)
    {   
        int xp = type switch
        {
            CollectibleType.small => 5,
            CollectibleType.medium => 8,
            CollectibleType.large => 15,
        };

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
