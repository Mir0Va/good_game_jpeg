using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerWave : MonoBehaviour
{
    [SerializeField] private ChangeSprite changesprite;
    [SerializeField] private TrailRenderer trail;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private CircleCollider2D _collider;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _amplitude = 0.5f;
    [SerializeField] private float _frequency = 20;
    [SerializeField] private PlayerMovement _playerMovement;
    
    private bool _playerIsWave;
    private Vector3 _pos;

    private bool _hasWaveCharge = true;

    void Update()
    {
        if (_playerMovement.IsGrounded())
        {
            _hasWaveCharge = true;
        }

        if (_playerInput.IsWaveButtonPressed && _hasWaveCharge)
        {
            DoWave();
        }
        else if (_playerIsWave)
        {
            StopWave();
        }
    }

    private void DoWave()
    {
        _collider.isTrigger = true;
        if (!_playerIsWave)
        {
            changesprite.ChangePlayerSprite();
            _pos = transform.position;
            _playerIsWave = true;
            changeTrail(); 
        }

        if (_playerMovement.IsFacingRight)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
    }

    private void StopWave()
    {
        _collider.isTrigger = false;
        _playerIsWave = false;
        _hasWaveCharge = false;
        changesprite.ChangePlayerSprite();
        changeTrail();
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -1);
    }


    private void MoveRight()
    {
        _pos += transform.right * (Time.deltaTime * _speed);
        transform.position = _pos + transform.up * (Mathf.Sin(Time.time * _frequency) * _amplitude);
    }

    private void MoveLeft()
    {
        _pos -= transform.right * (Time.deltaTime * _speed);
        transform.position = _pos + transform.up * (Mathf.Sin(Time.time * _frequency) * _amplitude);
    }

    private void changeTrail()
    {
        trail.enabled = !trail.enabled;
        trail.Clear();
    }
}