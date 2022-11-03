using System;
using UnityEngine;

[RequireComponent(typeof(CharacterAnimator))]
public class RelativeMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private DynamicJoystick _joystick;
    [SerializeField] private float _speed = 15f;
    [SerializeField] private float _rotationSpeed = 15f;

    private Transform _transform;

    public event Action OnRunStarted;
    public event Action OnRunEnded;

    #region MonoBehaviour

    private void Awake() => _transform = transform;

    private void Update() => TryMove();

    #endregion

    private void TryMove()
    {
        var movement = GetMovementVector();
        if (movement.x == 0 && movement.z == 0)
        {
            OnRunEnded?.Invoke();
            return;
        }

        OnRunStarted?.Invoke();
            
        ApplyBodyDirection(movement);

        movement = ApplyGravity(movement);
        Move(movement);
    }

    private void ApplyBodyDirection(Vector3 movement)
    {
        var direction = Quaternion.LookRotation(movement);
        _transform.rotation = Quaternion.Lerp(
            _transform.rotation,
            direction,
            _rotationSpeed * Time.deltaTime);
    }

    private Vector3 GetMovementVector()
    {
        var movement = new Vector3(
            _joystick.Horizontal,
            0,
            _joystick.Vertical);

        movement *= _speed;
        movement = Vector3.ClampMagnitude(movement, _speed);
        return movement;
    }

    private Vector3 ApplyGravity(Vector3 movement)
    {
        movement.y += Physics.gravity.y;
        return movement;
    }

    private void Move(Vector3 movement)
    {
        movement *= Time.deltaTime;
        _characterController.Move(movement);
    }
}
