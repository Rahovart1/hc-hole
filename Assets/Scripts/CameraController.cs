using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 _direction;

    private void FixedUpdate()
    {
        _direction = transform.position - _target.position;

        transform.rotation = Quaternion.LookRotation(-_direction, Vector3.up);
    }
}
