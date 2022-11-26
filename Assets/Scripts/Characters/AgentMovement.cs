using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Character), typeof(NavMeshAgent))]
public class AgentMovement : MonoBehaviour
{
    [SerializeField] private float _stopDistance = 3f;
    [SerializeField] [Range(0, 1.5f)] private float _movementBlockDuration = 1f;

    private Character _character;
    private NavMeshAgent _navMeshAgent;
    private Transform _target;
    private Transform _transform;
    private LayerMask _targetLayer;
    private bool _isMovementBlocked = false;
    private float _moveUpdateInterval = 0.1f;

    public event Action OnMovementStarted;
    public event Action OnMovementStopped;

    #region MonoBehaviour

    private void Awake()
    {
        InitFields();

        if (!_navMeshAgent.isOnNavMesh)
            Destroy(gameObject);

        StartCoroutine(Move());
    }

    #endregion

    public void SetTarget(Transform target) => _target = target;

    public void ApplyTargetLayer() => _targetLayer = _target.gameObject.layer;

    public void ApplySpeed() => _navMeshAgent.speed = _character.Stats.MovementSpeed;

    private void InitFields()
    {
        _character = GetComponent<Character>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _transform = transform;
    }

    private IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(_moveUpdateInterval);

            TrySetDestination();
            TryInvokeMovementEvents();
        }
    }

    private void TrySetDestination()
    {
        TryStopInFrontOfTarget();

        if (!_target)
            return;

        _navMeshAgent.SetDestination(_target.position);
    }

    private bool TryStopInFrontOfTarget()
    {
        var raycast = Physics.Raycast(_transform.position, _transform.forward, out var hit);
        if (raycast)
            if (!_isMovementBlocked && hit.collider.gameObject.layer == _targetLayer && hit.distance < _stopDistance)
            {
                StartCoroutine(BlockMovement());
                return true;
            }

        return false;
    }

    private IEnumerator BlockMovement()
    {
        _navMeshAgent.speed = 0f;
        _isMovementBlocked = true;

        yield return new WaitForSeconds(_movementBlockDuration);

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
