using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private CharacterAnimator _characterAnimator;
    [SerializeField] private DynamicJoystick _joystick;
    [SerializeField] private float _speed = 15f;
    [SerializeField] private float _rotationSpeed = 15f;

    private Transform _transform;

    #region MonoBehaviour

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        TryMove();
    }

    #endregion

    private void TryMove()
    {
        var movement = GetMovementVector();
        if (movement.x == 0 && movement.z == 0)
        {
            _characterAnimator.DisableRunning();
            return;
        }

        _characterAnimator.EnableRunning();
            
        ApplyBodyDirection(movement);

        movement = ApplyGravity(movement);
        Move(movement);
    }

    private void ApplyBodyDirection(Vector3 movement)
    {
        if (movement == Vector3.zero)
            return;

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
