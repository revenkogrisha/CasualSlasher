using SaveTheGuy.Characters;
using System;
using UnityEngine;

namespace SaveTheGuy.Control
{
    public class PlayerMovement : MonoBehaviour, IMoveable
    {
        [Header("Components")]
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Animator _animator;

        [Header("Settings")]
        [SerializeField] [Range(0f, 5f)] private float _horizontalSpeed = 5f;
        [SerializeField] [Range(0f, 10f)] private float _forwardSpeed = 5f;
        [Tooltip("Needed for clamping horizontal & forward speed")]
        [SerializeField] [Range(0f, 10f)] private float _maxSpeed = 5f;

        private Transform _transform;
        private MovementAnimator _characterAnimator;
        private PlayerInput _input;

        public event Action OnRunStarted;
        public event Action OnRunEnded;

        #region MonoBehaviour

        private void Awake()
        {
            _characterAnimator = new(_animator);
            _input = new();
            _transform = transform;
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

        public void TryMove(Vector3 movement)
        {
            if (CheckIsStationary(movement))
            {
                OnRunEnded?.Invoke();
                return;
            }

            OnRunStarted?.Invoke();

            movement = ApplyGravity(movement);
            Move(movement);
        }

        private Vector3 GetVectorWithSpeed(PlayerInput input)
        {
            var movement = input.GetMovementVector(_forwardSpeed, _horizontalSpeed);
            movement = Vector3.ClampMagnitude(movement, _maxSpeed);
            return movement;
        }

        private bool CheckIsStationary(Vector3 movement)
            => movement.x == 0 && movement.z == 0;

        private void ApplyBodyDirection(Vector3 movement)
        {
            if (movement == Vector3.zero)
                return;

            var direction = Quaternion.LookRotation(movement);

            _transform.rotation = Quaternion.Lerp(
                _transform.rotation,
                direction,
                _forwardSpeed * Time.deltaTime);
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
}
