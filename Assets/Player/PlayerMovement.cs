using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private CircleCollider2D _circleCollider;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    public bool IsFacingRight { get; set; } = true;

    private void Update()
    {
        CheckForMove();
        CheckForFlip();
        CheckForJump();
    }

    private void CheckForMove()
    {
        _rigidbody.velocity = new Vector2(_playerInput.MoveInputVector * _moveSpeed, _rigidbody.velocity.y);
    }

    private void CheckForFlip()
    {
        if (IsFacingRight && _playerInput.MoveInputVector < 0f 
            || !IsFacingRight && _playerInput.MoveInputVector > 0f)
        {
            Flip();
        }
    }

    private void CheckForJump()
    {
        if (_playerInput.IsJumpButtonPressed && IsGrounded())
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }

        if (_playerInput.IsJumpButtonCanceled && _rigidbody.velocity.y > 0f)
        {
            Vector2 currentVelocity = _rigidbody.velocity;
            _rigidbody.velocity = new Vector2(currentVelocity.x, currentVelocity.y * 0.5f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }

    private void Flip()
    {
        Transform playerTransform = transform;
        Vector3 localScale = playerTransform.localScale;
        
        IsFacingRight = !IsFacingRight;
        localScale.x *= -1f;
        playerTransform.localScale = localScale;
    }

}

