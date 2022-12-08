using UnityEngine;

public class PlatformGenerator : MonoBehaviour, ISurfaceGenerator
{
    [Header("Platforms")]
    [SerializeField] private Platform[] _platformsPrefabs;
    [SerializeField] private FinishPlatform _finishPlatformPrefab;

    [Header("Settings")]
    [SerializeField] private int _platformsPerLevel = 3;

    private readonly float _platformLength = 30f;
    private float _offset = 0f;

    public void GenerateSurface()
    {
        for (var i = 0; i < _platformsPerLevel; i++)
        {
            if (i == _platformsPerLevel - 1)
            {
                SpawnFinishPlatform();
                break;
            }

            SpawnRandomPlatform();
        }
    }

    private void SpawnFinishPlatform()
    {

    }

    private void SpawnRandomPlatform()
    {
        var random = Random.Range(0, _platformsPrefabs.Length);
        var platform = _platformsPrefabs[random];

        var position = Vector3.forward * _offset;
        Instantiate(platform, position, Quaternion.identity);

        _offset += _platformLength;
    }
}
