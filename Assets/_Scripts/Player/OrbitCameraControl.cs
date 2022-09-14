using UnityEngine;

public class OrbitCameraControl : MonoBehaviour
{
    [SerializeField] private Transform _target;
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
