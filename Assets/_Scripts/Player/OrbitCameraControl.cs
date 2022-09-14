using UnityEngine;

public class OrbitCameraControl : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _rotationSensivity = 4.5f;
    private Transform _transform;
    private Vector3 _offset;

    private void Awake()
    {
        _transform = transform;
        _offset = _target.position - _transform.position;
    }

    private void LateUpdate()
    {
        ApplyRotation();
    }

    private void ApplyRotation()
    {
        _transform.position = _target.position - _offset;
        _transform.LookAt(_target);
    }
}
