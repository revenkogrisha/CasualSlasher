using UnityEngine;
using UnityTools;

[RequireComponent(typeof(Timer))]
[RequireComponent(typeof(EnemyFactory))]
public class EnemyWaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private int _enemyCountInGroup;

    private Timer _timer;
    private EnemyFactory _factory;

    #region MonoBehaviour

    private void Awake()
    {
        _timer = GetComponent<Timer>();
        _factory = GetComponent<EnemyFactory>();
    }

    private void OnEnable()
    {
        _timer.OnCooldownPassed += SpawnRandomWave;
    }

    private void OnDisable()
    {
        _timer.OnCooldownPassed -= SpawnRandomWave;
    }

    #endregion

    public void SpawnRandomWave()
    {
        for (int i = 0; i < _enemyCountInGroup; i++)
        {
            var spawnPosition = GetPositionInCircle();

            var enemy = _factory.GetEnemy();

            Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }

    private Vector3 GetPositionInCircle()
    {
        var offset = Random.insideUnitCircle.normalized;
        offset *= _spawnRadius;

        var playerPosition = _playerTransform.position;

        return new Vector3(
            playerPosition.x + offset.x,
            playerPosition.y,
            playerPosition.z + offset.y);
    }
}
