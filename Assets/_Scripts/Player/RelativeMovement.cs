using System;
using UnityEngine;

[RequireComponent(typeof(CharacterAnimator))]
public class RelativeMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private DynamicJoystick _joystick;
    [SerializeField] private float _speed = 15f;
    [SerializeField] private float _rotationSpeed = 15f;

    public event Action OnRunStarted;
    public event Action OnRunEnded;

    private void Update() => TryMove();

    private void TryMove()
    {
        var movement = GetMovementVector();

        if (movement.x != 0|| movement.z != 0)
        {
            OnRunStarted?.Invoke();

            Move(movement);

            return;
        }

        OnRunEnded?.Invoke();
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

    private void Move(Vector3 movement)
    {
        movement.y += Physics.gravity.y;
        movement *= Time.deltaTime;
        _characterController.Move(movement);
    }
}
