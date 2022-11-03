using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CharacterAnimator))]
public class RelativeMovement : MonoBehaviour
{
    [SerializeField] private DynamicJoystick _joystick;
    [SerializeField] private float _speed = 15f;
    [SerializeField] private float _rotationSpeed = 15f;

    private Vector3 _movement;
    private Transform _transform;
    private Transform _camera;
    private CharacterController _characterController;
    private CharacterAnimator _animator;

    public event Action OnRunStarted;
    public event Action OnRunEnded;

    private void Awake()
    {
        _transform = transform;
        _camera = Camera.main.transform;
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<CharacterAnimator>();
    }

    private void Update()
    {
        TryMove();
    }

    private void TryMove()
    {
        var horizontal = _joystick.Horizontal;
        var vertical = _joystick.Vertical;

        if (horizontal != 0 || vertical != 0)
        {
            OnRunStarted?.Invoke();

            _movement = new(horizontal, 0f, vertical);
            _movement *= _speed;
            _movement = Vector3.ClampMagnitude(_movement, _speed);

            Move();

            return;
        }

        OnRunEnded?.Invoke();
    }

    private void Move()
    {
        _movement.y += Physics.gravity.y;
        _movement *= Time.deltaTime;
        _characterController.Move(_movement);
    }
}
