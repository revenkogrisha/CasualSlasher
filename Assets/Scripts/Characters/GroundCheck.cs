using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _checkSphere;
    [SerializeField] private float _checkRadius;

    public bool IsOnGround =>
        Physics.CheckSphere(_checkSphere.position, _checkRadius, _groundLayer);

    public bool CheckGroundOnPosition(Vector3 position) =>
        Physics.CheckSphere(position, _checkRadius, _groundLayer);
}
