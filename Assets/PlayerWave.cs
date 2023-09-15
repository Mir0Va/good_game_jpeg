using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWave : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerinput;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private CircleCollider2D _collider;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _amplitude = 0.5f;
    [SerializeField] private  float _frequency = 20;
    [SerializeField] private PlayerMovement _playermovement;
    [SerializeField] private PlayerDeath _playerdeath;
    [SerializeField] private LayerMask _wallLayer;

    private Vector3 pos, localScale; 

    void Start()
    {
        localScale = transform.localScale;
    }

    void Update()
    {
        if (_playerinput.IsWaveButtonPressed)
        {
            _collider.isTrigger = true;
            //check facing of player, for now just right
            if (_playermovement.IsFacingRight)
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }
        }
        else
        {
            pos = transform.position;
            _collider.isTrigger = false;
            if (IsInsideWall())
            {
                _playerdeath.Die();
            }
        }
    }
    
    private void MoveRight()
    {
        pos += transform.right * (Time.deltaTime * _speed);
        transform.position = pos + transform.up * (Mathf.Sin(Time.time * _frequency) * _amplitude);
    }

    private void MoveLeft()
    {
        pos -= transform.right * (Time.deltaTime * _speed);
        transform.position = pos + transform.up * (Mathf.Sin(Time.time * _frequency) * _amplitude);
    }

    private bool IsInsideWall()
    {
        return Physics2D.OverlapCircle(transform.position, 0.1f, _wallLayer);
    }
}
