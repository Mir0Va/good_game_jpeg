using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class RopeMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isRope;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private PlayerInput _playerInput;


    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Rope"))
            {
                isRope = true;
            }
        }

    private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Rope"))
            {
                isRope = false;
                isClimbing = false;
            }
        }

    private void Update()
    {
        if (isRope && _playerInput.IsJumpButtonPressed)
        {
            _body.velocity = new Vector2(_body.velocity.x, vertical*speed + _body.gravityScale);
        }
    }

}
