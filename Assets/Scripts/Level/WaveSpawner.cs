using UnityEngine;
using UnityTools;

[RequireComponent(typeof(Timer))]
[RequireComponent(typeof(CharacterFactory))]
public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform _originTransform;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private int _countInGroup;

    private Timer _timer;
    private CharacterFactory _factory;

    #region MonoBehaviour

    private void Awake()
    {
        _timer = GetComponent<Timer>();
        _factory = GetComponent<CharacterFactory>();
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
        for (int i = 0; i < _countInGroup; i++)
        {
            var spawnPosition = GetPositionInCircle(_originTransform.position, _spawnRadius);

            var enemy = _factory.GetEnemy();

            Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }

    private Vector3 GetPositionInCircle(Vector3 center, float radius)
    {
        var offset = Random.insideUnitCircle.normalized;
        offset *= radius;

        return new Vector3(
            center.x + offset.x,
            center.y,
            center.z + offset.y);
    }
}
