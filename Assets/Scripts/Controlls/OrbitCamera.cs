using UnityEngine;

namespace CasualSlasher.Control
{
    public class OrbitCamera : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Camera _camera;
        
        [Header("Target to follow")]
        [SerializeField] private Transform _target;

        [Header("Settings")]
        [SerializeField] private Vector3 _cameraOffset = new(0f, 4f, -10f);

        private Transform _transform;
        private Vector3 _distanceToTarget;

        private void Awake()
        {
            var targetPosition = _target.position;
            _transform = _camera.transform;

            SetPosition(targetPosition);
            _distanceToTarget = _target.position - _transform.position;
        }

        private void LateUpdate() => TryApplyCameraTransform();

        public void TryApplyCameraTransform()
        {
            if (!_target)
                return;

            _transform.position = _target.position - _distanceToTarget;
            _transform.LookAt(_target);
        }

        private void SetPosition(Vector3 targetPosition)
        {
            var cameraPosition = new Vector3(
                targetPosition.x + _cameraOffset.x,
                targetPosition.y + _cameraOffset.y,
                targetPosition.z + _cameraOffset.z);
        
            _transform.position = cameraPosition;
        }
    }
}
