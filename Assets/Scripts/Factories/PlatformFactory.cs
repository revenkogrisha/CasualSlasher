using ColorManRun.ColorFeatures;
using ColorManRun.Level;
using UnityEngine;

namespace ColorManRun.Factories
{
    public class PlatformFactory
    {
        private readonly ColorTrioPicker _colorPicker;
        private readonly ColorPlatform[] _platformsPrefabs;

        public PlatformFactory(
            ColorPlatform[] platformsPrefabs,
            ColorTrioPicker colorPicker)
        {
            _platformsPrefabs = platformsPrefabs;
            _colorPicker = colorPicker;
        }

        public ColorPlatform GetRandomColorPlatform(out GameColor color)
        {
            var randomPlatformIndex = Random.Range(0, _platformsPrefabs.Length);
            var platform = _platformsPrefabs[randomPlatformIndex];

            color = SetPlatformColor(platform);
            return platform;
        }

        private GameColor SetPlatformColor(ColorPlatform platform)
        {
            var color = _colorPicker.GetRandomColor();
            var material = _colorPicker.GetMaterialByColor(color);

            platform.SetColor(color, material);
            return color;
        }
    }
}
