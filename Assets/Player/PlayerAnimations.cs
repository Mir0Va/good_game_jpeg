using System;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _leftLeg;
    [SerializeField] private Transform _rightLeg;
    [SerializeField] private Transform _leftHand;
    [SerializeField] private Transform _rightHand;
    [SerializeField] private RopeMovement _ropeMovement;
    
    [SerializeField] private float _amplitude = 1.0f;
    [SerializeField] private float _frequency = 1.0f;
    [SerializeField] private float _offset;
    [SerializeField] private float _rotationAngle = 15.0f;
    [SerializeField] private float _rotationSpeed = 5.0f;
    
    private int _legAnimDirection = 1;
    private Quaternion _leftLegInitialRotation;
    private Quaternion _rightLegInitialRotation;
    
    private Vector3 _leftHandInitialPosition;
    private Vector3 _rightHandInitialPosition;

    private void Start()
    {
        _leftLegInitialRotation = _leftLeg.localRotation;
        _rightLegInitialRotation = _rightLeg.localRotation;
        
        _leftHandInitialPosition = _leftHand.localPosition;
        _rightHandInitialPosition = _rightHand.localPosition;
    }

    private void Update()
    {
        if (_rigidbody.velocity.x != 0)
        {
            AnimateLegs();
            AnimateHands();
        }
        else if (_ropeMovement.IsClimbing)
        {
            Debug.Log("Climbing...");
            AnimateLegs();
            AnimateHands();
        }
        else
        {
            ResetLegs();
            ResetHands();
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

    private void AnimateHands()
    {
        float verticalMovement = Mathf.Sin(Time.time * _frequency + _offset) * _amplitude;
        
        _leftHand.localPosition = _leftHandInitialPosition + new Vector3(0, verticalMovement, 0);
        _rightHand.localPosition = _rightHandInitialPosition - new Vector3(0, verticalMovement, 0);
    }

    private void ResetLegs()
    {
        _leftLeg.localRotation = _leftLegInitialRotation;
        _rightLeg.localRotation = _rightLegInitialRotation;
    }
    
    private void ResetHands()
    {
        _leftHand.localPosition = _leftHandInitialPosition;
        _rightHand.localPosition = _rightHandInitialPosition;
    }
}
