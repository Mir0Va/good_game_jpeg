using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CrushingWall : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool _startMovingRight;
    [SerializeField] private float _wallDetectionDistance;
    [SerializeField] private LayerMask _wallLayer;
    
    private float _direction;

    private void Start()
    {
        _direction = _startMovingRight ? 1 : -1;
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector2(_moveSpeed * _direction, 0);
        
        Debug.DrawRay(transform.position, Vector2.right * (_direction * _wallDetectionDistance), Color.red);

        if (IsHittingWall())
        {
            _direction *= -1;
        }
    }
    
    private bool IsHittingWall()
    {
        if (Physics2D.Raycast(transform.position, Vector2.right * _direction, _wallDetectionDistance, _wallLayer))
        {
            return true;
        }

        return false;
    }
    
}
