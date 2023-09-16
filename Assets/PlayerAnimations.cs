using System;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _rotationAngle = 15.0f;
    [SerializeField] private float _rotationSpeed = 5.0f;
    [SerializeField] private Transform _leftLeg;
    [SerializeField] private Transform _rightLeg;
    
    private int _legAnimDirection = 1;
    private Quaternion _leftLegInitialRotation;
    private Quaternion _rightLegInitialRotation;

    private void Start()
    {
        _leftLegInitialRotation = _leftLeg.localRotation;
        _rightLegInitialRotation = _rightLeg.localRotation;
    }

    private void Update()
    {
        if (_rigidbody.velocity.x != 0)
        {
            AnimateLegs();
        }
        else
        {
            ResetLegs();
        }
    }

    private void AnimateLegs()
    {
        float rotationAmount = _rotationAngle * _legAnimDirection;
        float rotationStep = _rotationSpeed * Time.deltaTime;
        
        _leftLeg.Rotate(Vector3.forward * (rotationAmount * rotationStep));
        _rightLeg.Rotate(Vector3.forward * (-rotationAmount * rotationStep));
        
        if (_leftLeg.localRotation.eulerAngles.z is >= 45.0f or <= -45.0f)
        {
            _legAnimDirection *= -1;
        }
    }

    private void ResetLegs()
    {
        _leftLeg.localRotation = _leftLegInitialRotation;
        _rightLeg.localRotation = _rightLegInitialRotation;
    }
}
