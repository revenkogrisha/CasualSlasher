using UnityEngine;

public class OrbitCameraControl : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _rotationSensivity = 4.5f;
    private Transform _transform;
    private float _rotationY;
    private Vector3 _offset;

    private void Awake()
    {
        _transform = transform;
        _rotationY = _transform.eulerAngles.y;
        _offset = _target.position - _transform.position;
    }

    private void LateUpdate()
    {
        GetRotation();
        ApplyRotation();
    }

    private void GetRotation()
    {
        var mouseInputX = Input.GetAxis(Axis.MouseX);
        _rotationY += mouseInputX * _rotationSensivity;
    }

    private void ApplyRotation()
    {
        Quaternion rotation = Quaternion.Euler(0, _rotationY, 0);
        _transform.position = _target.position - (rotation * _offset);
        _transform.LookAt(_target);
    }
}
