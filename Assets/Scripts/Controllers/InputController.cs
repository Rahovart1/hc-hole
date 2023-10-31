using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Vector3 _startPos;
    private Vector3 _direction;
    private bool _isTouching; 
    private void Start()
    {
        _isTouching = false;
    }
    private void Update()
    {
        InputHandle();
    }

    private void InputHandle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPos = Input.mousePosition;
            _isTouching = true;
        }
        else if (Input.GetMouseButton(0))
        {
            _direction = (Input.mousePosition - _startPos).normalized;
        }
        else
        {
            _direction = Vector3.zero;
            _isTouching = false;
        }
    }

    public Vector3 GetDirection() => _direction;
}
