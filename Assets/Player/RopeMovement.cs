using UnityEngine;

public class RopeMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isRope;

    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private PlayerInput _playerInput;

    public bool IsClimbing { get; private set; }


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
            }
        }

    private void Update()
    {
        if (isRope && _playerInput.IsJumpButtonPressed)
        {
            _body.velocity = new Vector2(_body.velocity.x, vertical*speed + _body.gravityScale);
            IsClimbing = true;
        }
        else
        {
            IsClimbing = false;
        }
    }

}
