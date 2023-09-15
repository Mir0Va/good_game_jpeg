using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_wave : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerinput;
    [SerializeField] private RigidBody2D _rigidbody;
    [SerializeField] private CircleCollider2D _collider:
    private float speed = 5;
    private float amplitude = 0.5;
    private float frequency = 20;
    private bool facing_right = true;

    private Vector3 pos, localScale; 

    void Start()
    {
        pos = transform.position;

        localScale = transform.localScale;

        _collider.isTrigger = true:
    }

    void Update()
    {
        if (_playerinput.isWaveButtonPressed)
        {
            //check facing of player, for now just right
            moveRight()
        }
        else
        {
            _collider.isTrigger = false:
        }
    }
    
    private void moveRight()
    {
        pos += transform.right * Time.deltaTime * speed;
        transform.position = pos + transform.up*Mathf.sin(Time.time * frequency)*amplitude 
    }

}
