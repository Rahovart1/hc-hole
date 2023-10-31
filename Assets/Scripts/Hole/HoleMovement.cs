using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _duration;
    [SerializeField] private float _smooth;

    private InputController _inputs;

    private float _horizontalInput;
    private float _verticalInput;
    private float _offsetSize;
    private Vector3 _moveDirection;
    private Vector3 _temp;
    private Vector3 _inputDirection;
    private bool _canMove;

    private void Start()
    {
        _canMove = true;
        _offsetSize = transform.localScale.x;
        _inputs = GetComponent<InputController>();
    }
    private void OnEnable()
    {
        EventManager.Instance.onFirstStageEnd.AddListener(FirstStageEnd);    
    }
    private void OnDisable()
    {    
        EventManager.Instance.onFirstStageEnd.RemoveListener(FirstStageEnd);    
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_canMove)
        {
            //_horizontalInput = Input.GetAxis("Horizontal");
            //_verticalInput = Input.GetAxis("Vertical");

            _inputDirection = _inputs.GetDirection();

            _moveDirection = Vector3.forward * _inputDirection.y + Vector3.right * _inputDirection.x;
            transform.position += _moveDirection * _moveSpeed * Time.fixedDeltaTime;

            transform.position = new(Mathf.Clamp(transform.position.x, -_maxDistance + _offsetSize, _maxDistance - _offsetSize), 0, Mathf.Clamp(transform.position.z, -0.5f + _offsetSize, _maxDistance - _offsetSize));
        }
    }
    
    public void FirstStageEnd()
    {
        Debug.Log("testsdads");
        _canMove = false;
        StartCoroutine(SetPosition());
    }

    private IEnumerator SetPosition()
    {
        float _elapsedTime = 0f;

        while (_elapsedTime <= _duration)
        {
            _elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, Vector3.zero, _smooth * Time.deltaTime);

            yield return null;
        }

        transform.position = Vector3.zero;
    }
}
