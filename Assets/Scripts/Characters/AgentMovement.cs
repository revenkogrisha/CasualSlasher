using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentMovement : MonoBehaviour
{
    [SerializeField] private IStatisticsCarrier _statsCarrier;

    private Transform _target;
    private NavMeshAgent _navMeshAgent;

    #region MonoBehaviour

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _navMeshAgent.speed = _statsCarrier.Stats.MovementSpeed;
    }

    private void Update()
    {
        if (_target)
            _navMeshAgent.SetDestination(_target.position);
    }

    #endregion

    public void SetTarget(Transform target) => _target = target;
}
