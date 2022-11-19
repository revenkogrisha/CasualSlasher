using System;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    private Transform _target;

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

    public void SetSpeed() => _navMeshAgent.speed = _character.Stats.MovementSpeed;

    private void TrySetDestination()
    {
        if (_target && _navMeshAgent.isOnNavMesh)
            _navMeshAgent.SetDestination(_target.position);
    }

    private void TryInvokeMovementEvents()
    {
        if (_navMeshAgent.isStopped)
            OnMovementStopped?.Invoke();
        else
            OnMovementStarted?.Invoke();
    }
}
