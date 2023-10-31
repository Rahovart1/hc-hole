using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private Animator _anim;
    private bool _canMove;
    private void Start()
    {
        _canMove = false;    
    }
    private void OnEnable()
    {
        EventManager.Instance.onSecondStageStart.AddListener(SecondStageStart);
    }

    private void OnDisable()
    {
        EventManager.Instance.onSecondStageStart.RemoveListener(SecondStageStart);
    }

    private void FixedUpdate()
    {
        if (_canMove)
            MovementHandle();    
    }

    private void MovementHandle() => transform.position += _velocity * Time.deltaTime;

    public void SecondStageStart()
    {
        //start anim
        _canMove = true;
    }
}
