using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxDistance;

    private float _horizontalInput;
    private float _verticalInput;
    private Vector3 _moveDirection;
    private Vector3 _temp;
    private float _offsetSize;

    private void FixedUpdate()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _offsetSize = transform.localScale.x;

        _moveDirection = Vector3.forward * _verticalInput + Vector3.right * _horizontalInput;
        transform.position += _moveDirection * _moveSpeed * Time.fixedDeltaTime;

        transform.position = new(Mathf.Clamp(transform.position.x, -_maxDistance + _offsetSize, _maxDistance - _offsetSize), 0, Mathf.Clamp(transform.position.z, -0.5f + _offsetSize, _maxDistance - _offsetSize));
    }
}
