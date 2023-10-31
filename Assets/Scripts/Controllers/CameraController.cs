using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _firstStageTarget;
    [SerializeField] private Transform _secondStageTarget;
    private Transform _target;
    private Vector3 _direction;
    private void Start() 
    {
        _target = _firstStageTarget;    
    }
    private void OnEnable()
    {
        EventManager.Instance.onFirstStageStart.AddListener(FirstStage);    
        EventManager.Instance.onSecondStageStart.AddListener(SecondStage);    
    }
    private void OnDisable()
    {
        Debug.Log("camera");
        EventManager.Instance.onFirstStageStart.RemoveListener(FirstStage);    
        EventManager.Instance.onSecondStageStart.RemoveListener(SecondStage);    
    }

    private void LateUpdate()
    {
        if (_target == null) return;

        transform.position = _target.position;
        transform.rotation = _target.rotation;
    }

    public void FirstStage()
    {
        SwitchTarget(_firstStageTarget);
    }
    public void SecondStage()
    {
        SwitchTarget(_secondStageTarget);
    }
    private void SwitchTarget(Transform obj)
    {
        _target = obj;
    }
}
