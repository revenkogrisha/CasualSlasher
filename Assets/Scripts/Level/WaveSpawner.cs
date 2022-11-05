using UnityEngine;
using UnityTools;

[RequireComponent(typeof(Timer))]
public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private CharacterFactory _factory;
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private Character _characterPrefab;
    [SerializeField] private Transform _originTransform;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private int _countInGroup;

    private Timer _timer;

    #region MonoBehaviour

    private void Awake()
    {
        _timer = GetComponent<Timer>();
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
        var i = 0;
        while (i < _countInGroup)
        {
            var spawnPosition = GetPositionInCircle(_originTransform.position, _spawnRadius);
            if (!_groundCheck.CheckGroundOnPosition(spawnPosition))
                continue;

            var character = Instantiate(_characterPrefab, spawnPosition, Quaternion.identity);

            _factory.InitCharacter(character);

            i++;
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
