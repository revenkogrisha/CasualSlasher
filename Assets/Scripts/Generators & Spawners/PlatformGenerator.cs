using ColorManRun.ColorFeatures;
using ColorManRun.Factories;
using ColorManRun.Level;
using UnityEngine;
using UnityTools;

namespace ColorManRun.Generators
{
    public class PlatformGenerator : MonoBehaviour, ISurfaceGenerator
    {
        private const int ColorBubblesAmount = 2;

        [Header("Components")]
        [SerializeField] private ColorTrio _colorPicker;

        [Header("Platforms")]
        [SerializeField] private FirstPlatform _firstPlatformPrefab;
        [SerializeField] private FinishPlatform _finishPlatformPrefab;
        [SerializeField] private ColorPlatform[] _platformsPrefabs;

        [Header("Platforms' parent")]
        [Tooltip("Opional")]
        [SerializeField] private LevelObjectsParent _parent;

        [Header("ColorBubbles")]
        [SerializeField] private ColorBubble[] _colorBubbles;
        [SerializeField] private ColorBubblesPair _colorBubblesPairPrefab;

        [Header("Settings")]
        [SerializeField] private int _platformsPerLevel = 3;

        private readonly float _platformLength = 30f;
        private float _offset = 0f;
        private PlatformFactory _platformFactory;

        #region MonoBehaviour

        private void Awake()
        {
            _platformFactory = new(_platformsPrefabs, _colorPicker);
        }

        #endregion

        public FinishTarget GenerateSurface()
        {
            SpawnPlatform(_firstPlatformPrefab);
            for (var i = 1; i < _platformsPerLevel - 1; i++)
                SpawnRandomPlatform();

            return SpawnFinishPlatform();
        }

        private void SpawnRandomPlatform()
        {
            var platform =
                _platformFactory.GetRandomColorPlatform(out var color);
            platform = SetColorBubbles(platform, color);
            SpawnPlatform(platform);
        }

        private FinishTarget SpawnFinishPlatform()
        {
            var platform = SpawnPlatform(_finishPlatformPrefab);
            return GetFinishTarget(platform);
        }

        private ColorPlatform SetColorBubbles(ColorPlatform platform, GameColor color)
        {
            var bubblesPair = Instantiate(_colorBubblesPairPrefab);

            ColorBubble firstBubble = null;
            ColorBubble secondBubble = null;

            int i = 0;
            while (i < ColorBubblesAmount)
            {
                var random = Random.Range(0, _colorBubbles.Length);
                var bubble = _colorBubbles[random];
                if (bubble.Color.Equals(color))
                    continue;

                if (i == 0)
                    firstBubble = bubble;
                else if (i == 1)
                    secondBubble = bubble;
                else
                    throw new System.Exception("Unexpected cycle iteration");

                i++;
            }

            if (firstBubble == null || secondBubble == null)
                throw new System.NullReferenceException("One of bubbles is null");

            bubblesPair.Init(firstBubble, secondBubble);

            platform.SetBubblesPair(bubblesPair);
            return platform;
        }

        private T SpawnPlatform<T>(T prefab)
            where T : Platform
        {
            var position = Vector3.forward * _offset;
            var platform = Instantiate(prefab, position, Quaternion.identity);
            _offset += _platformLength;
            return TrySetParent(platform);
        }

        private T TrySetParent<T>(T platform)
            where T : Platform
        {
            if (_parent == null)
                return platform;

            var platformTransform = platform.transform;
            platformTransform.SetParent(_parent.transform);
            return platform;
        }

        private FinishTarget GetFinishTarget(FinishPlatform platform) => platform.Finish;
    }
}