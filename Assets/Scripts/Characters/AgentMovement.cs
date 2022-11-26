using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Transform _hitSphere;
    [SerializeField] private float _hitRadius;
    [SerializeField] private float _stopDistance = 3f;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    private Transform _target;
    private LayerMask _targetLayer;
    private bool _isMovementBlocked = false;

    public event Action OnMovementStarted;
    public event Action OnMovementStopped;

    #region MonoBehaviour

    private void Awake()
    {
        if (!_navMeshAgent.isOnNavMesh)
            Destroy(gameObject);
    }

    private void Update()
    {
        TrySetDestination();
        TryInvokeMovementEvents();
    }

    #endregion

    public void SetTarget(Transform target) => _target = target;

    public void ApplyTargetLayer() => _targetLayer = _target.gameObject.layer;

    public void ApplySpeed() => _navMeshAgent.speed = _character.Stats.MovementSpeed;

    private void TrySetDestination()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit))
            if (!_isMovementBlocked && hit.collider.gameObject.layer == _targetLayer && hit.distance < _stopDistance)
                StartCoroutine(BlockMovement());

        if (!_target)
            return;

        _navMeshAgent.SetDestination(_target.position);
    }

    private IEnumerator BlockMovement()
    {
        _navMeshAgent.speed = 0f;
        _isMovementBlocked = true;

        yield return new WaitForSeconds(1f);

        ApplySpeed();
        _isMovementBlocked = false;
    }

    private void TryInvokeMovementEvents()
    {
        if (_navMeshAgent.isStopped)
            OnMovementStopped?.Invoke();
        else
            OnMovementStarted?.Invoke();
    }
}
