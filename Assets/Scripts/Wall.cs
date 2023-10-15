using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side
{
    e,
    w,
    n,
    s
}

public class Wall : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _distance;
    [SerializeField] private Side _side;
    [SerializeField] private Vector2 _moveSpeed;
    private Material _material;
    private Color _color;
    private float _tempDistance;

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
        _color = _material.color;
    }

    private void FixedUpdate()
    {
        CheckDistance();
        Move();
    }

    private void Move()
    {
        _material.mainTextureOffset += _moveSpeed * Time.fixedDeltaTime; 
    }
    private void CheckDistance()
    {
        if (_target != null)
        {
            switch (_side)
            {
                case Side.e:
                    _tempDistance = Mathf.Abs(transform.position.x - _target.position.x);
                    if (_tempDistance < _distance)
                    {
                        _color.a = _distance - _tempDistance;
                        _material.color = _color;
                    }
                    else
                    {
                        _color.a = 0.1f;
                        _material.color = _color;
                    }
                    break;

                case Side.w:
                    _tempDistance = Mathf.Abs(transform.position.x - _target.position.x);
                    if (_tempDistance < _distance)
                    {
                        _color.a = _distance - _tempDistance;
                        _material.color = _color;
                    }
                    else
                    {
                        _color.a = 0.1f;
                        _material.color = _color;
                    }
                    break;

                case Side.n:
                    _tempDistance = Mathf.Abs(transform.position.z - _target.position.z);
                    if (_tempDistance < _distance)
                    {
                        _color.a = _distance - _tempDistance;
                        _material.color = _color;
                    }
                    else
                    {
                        _color.a = 0.1f;
                        _material.color = _color;
                    }
                    break;

                case Side.s:
                    _tempDistance = Mathf.Abs(transform.position.z - _target.position.z);
                    if (_tempDistance < _distance)
                    {
                        _color.a = _distance - _tempDistance;
                        _material.color = _color;
                    }
                    else
                    {
                        _color.a = 0.1f;
                        _material.color = _color;
                    }
                    break;
            }
        }
    }
}
