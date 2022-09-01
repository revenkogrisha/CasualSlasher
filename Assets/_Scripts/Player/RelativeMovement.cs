using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CharacterAnimator))]
public class RelativeMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 15f;
    [SerializeField] private float _rotationSpeed = 15f;

    private Vector3 _movement;
    private Transform _transform;
    private Transform _camera;
    private CharacterController _characterController;
    private CharacterAnimator _animator;
    private RelativeJump _relativeJump;

    public event Action OnRunStarted;
    public event Action OnRunEnded;

    private void Awake()
    {
        _transform = transform;
        _camera = Camera.main.transform;
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<CharacterAnimator>();
        _relativeJump = GetComponent<RelativeJump>();
    }

    private void Update()
    {
        TryMove();
    }

    private void TryMove()
    {
        var horizontal = Input.GetAxis(Axis.Horizontal);
        var vertical = Input.GetAxis(Axis.Vertical);

        if (horizontal != 0 || vertical != 0)
        {
            OnRunStarted?.Invoke();

            _movement = new(horizontal, 0f, vertical);
            _movement *= _speed;
            _movement = Vector3.ClampMagnitude(_movement, _speed);

            SetMovementRelativeToCamera();
        }
        
        OnRunEnded?.Invoke();

        Move();
    }

    private void SetMovementRelativeToCamera()
    {
        Quaternion temporary = _camera.rotation;
        _camera.eulerAngles = new(0, _camera.eulerAngles.y, 0);
        _movement = _camera.TransformDirection(_movement);
        _camera.rotation = temporary;
        
        var direction = Quaternion.LookRotation(_movement);
        _transform.rotation = Quaternion.Lerp(
            _transform.rotation, direction, _rotationSpeed * Time.deltaTime);
    }

    private void Move()
    {
        _movement.y += _relativeJump.TryGetJumpY();
        _movement.y += Physics.gravity.y;
        _movement *= Time.deltaTime;
        _characterController.Move(_movement);
    }
}
