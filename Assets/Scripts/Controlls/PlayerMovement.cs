using CasualSlasher.Characters;
using System;
using UnityEngine;

namespace CasualSlasher.Control
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Animator _animator;
        [SerializeField] private Joystick _joystick;

        [Header("Settings")]
        [SerializeField] [Range(0f, 20f)] private float _speed = 5f;
        [Tooltip("Needed for clamping horizontal & forward speed")]
        [SerializeField] [Range(0f, 20f)] private float _maxSpeed = 5f;
        [SerializeField] [Range(0f, 10f)] private float _rotationSpeed = 10f;

        private MovementAnimator _characterAnimator;
        private PlayerInput _input;
        private Transform _transform;

        public event Action OnRunStarted;
        public event Action OnRunEnded;

        #region MonoBehaviour

        private void Awake()
        {
            _transform = transform;
            _characterAnimator = new(_animator);
            _input = new();
        }

        private void OnEnable()
        {
            OnRunStarted += _characterAnimator.EnableRunning;
            OnRunEnded += _characterAnimator.DisableRunning;
        }
    
        private void OnDisable()
        {
            OnRunStarted -= _characterAnimator.EnableRunning;
            OnRunEnded -= _characterAnimator.DisableRunning;
        }

        private void Update()
        {
            var movement = GetVectorWithSpeed(_input);
            TryMove(movement);
        }

        #endregion

        public void Init(Joystick joystick) => _joystick = joystick;

        public void TryMove(Vector3 movement)
        {
            if (CheckIfStationary(movement))
            {
                OnRunEnded?.Invoke();
                return;
            }

            OnRunStarted?.Invoke();

            ApplyBodyDirection(movement);

            movement = ApplyGravity(movement);
            Move(movement);
        }

        private bool CheckIfStationary(Vector3 movement)
            => movement.x == 0 && movement.z == 0;

        private Vector3 GetVectorWithSpeed(PlayerInput input)
        {
            var movement = input.GetMovementVector(_joystick, _speed);
            movement = Vector3.ClampMagnitude(movement, _maxSpeed);
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

        private void ApplyBodyDirection(Vector3 movement)
        {
            if (movement == Vector3.zero)
                return;

            var direction = Quaternion.LookRotation(movement);

            _transform.rotation = Quaternion.Lerp(
            _transform.rotation, direction, _rotationSpeed * Time.deltaTime);
        }
    }
}