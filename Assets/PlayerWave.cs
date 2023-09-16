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

    private bool _playerUsedWave = false;
    private Vector3 pos, localScale; 

    void Start()
    {
        localScale = transform.localScale;
    }

    void Update()
    {
        if (_playerinput.IsWaveButtonPressed)
        {
            if (_playerUsedWave)
            {
                pos = transform.position;
                _playerUsedWave = false;
            }
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
            _collider.isTrigger = false;
            _playerUsedWave = true;
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

}
