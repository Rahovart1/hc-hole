using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _timer;
    [SerializeField] private GameObject _tapToStart;
    [SerializeField] private GameObject _weaponButtons;

    private void OnEnable()
    {
        EventManager.Instance.onFirstStageStart.AddListener(FirstStageStart);
        EventManager.Instance.onFirstStageEnd.AddListener(FirstStageEnd);
        EventManager.Instance.onSecondStageStart.AddListener(SecondStageStart);
    }
    private void onDisable()
    {
        EventManager.Instance.onFirstStageStart.RemoveListener(FirstStageStart);
        EventManager.Instance.onFirstStageEnd.RemoveListener(FirstStageEnd);
        EventManager.Instance.onSecondStageStart.RemoveListener(SecondStageStart);
    }

    public void FirstStageStart()
    {
        _timer.SetActive(true);
        _tapToStart.SetActive(false);
    }

    public void FirstStageEnd()
    {
        _timer.SetActive(false);
        _tapToStart.SetActive(true);
    }

    public void SecondStageStart()
    {
        _tapToStart.SetActive(false);
        _weaponButtons.SetActive(true);
    }


}
