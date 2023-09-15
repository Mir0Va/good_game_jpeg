using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    private void Update()
    {
        if (_playerInput.IsWaveButtonPressed)
        {
        }
    }

}

