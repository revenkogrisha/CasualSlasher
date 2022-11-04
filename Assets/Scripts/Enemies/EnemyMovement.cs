using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform _target;
    private NavMeshAgent _thisAgent;
    private Enemy _enemy;

    #region MonoBehaviour

    private void Awake()
    {
        _thisAgent = GetComponent<NavMeshAgent>();
        _enemy = GetComponent<Enemy>();

        _thisAgent.speed = _enemy.Stats.MovementSpeed;
    }

    private void Update()
    {
        if (_target)
            _thisAgent.SetDestination(_target.position);
    }

    #endregion

    public void SetTarget(Transform target) => _target = target;
}
