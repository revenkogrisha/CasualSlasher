using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    private Transform _target;

    #region MonoBehaviour

    private void Awake()
    {
        if (!_navMeshAgent.isOnNavMesh)
            Destroy(gameObject);
    }

    private void Update() => TrySetDestination();

    #endregion

    private void TrySetDestination()
    {
        if (_target && _navMeshAgent.isOnNavMesh)
            _navMeshAgent.SetDestination(_target.position);
    }

    public void SetTarget(Transform target) => _target = target;

    public void SetSpeed() => _navMeshAgent.speed = _character.Stats.MovementSpeed;
}
