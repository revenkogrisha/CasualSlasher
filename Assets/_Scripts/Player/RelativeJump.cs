using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(RelativeMovement))]
public class RelativeJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _duration = 0.8f;
    [SerializeField] private AnimationCurve _yJumpCurve;

    private CharacterController _characterController;
    private RelativeMovement _relativeMovement;
    private bool _isJumping = false;
    private float _expiredTime;

    public event Action OnJumpStarted;
    public event Action OnJumpEnded;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _relativeMovement = GetComponent<RelativeMovement>();
    }

    public float TryGetJumpY()
    {
        if (Input.GetButtonDown(Axis.Jump)
            && _characterController.isGrounded)
        {
            _isJumping = true;
        }

        if (_isJumping)
        {
            _expiredTime += Time.deltaTime;

            if (_expiredTime > _duration)
            {
                OnJumpEnded?.Invoke();

                _isJumping = false;
                _expiredTime = 0f;
            }

            OnJumpStarted?.Invoke();

            float progress = _expiredTime / _duration;

            return GetJumpY(progress);
        }
        
        OnJumpEnded?.Invoke();

        return 0f;
    }

    private float GetJumpY(float progress)
    {
        var movementY = _yJumpCurve.Evaluate(progress);
        movementY *= _jumpForce;

        return movementY;
    }
}
