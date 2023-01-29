using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorManRun.Level;
using ColorManRun.ColorFeatures;

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

        public ColorPlatform GetRandomColorPlatform()
        {
            var randomPlatformIndex = Random.Range(0, _platformsPrefabs.Length);
            var platform = _platformsPrefabs[randomPlatformIndex];

            platform = SetPlatformColor(platform);
            return platform;
        }

        private ColorPlatform SetPlatformColor(ColorPlatform platform)
        {
            var color = _colorPicker.GetRandomColor();
            var material = _colorPicker.GetMaterialByColor(color);

            platform.SetColor(color, material);
            return platform;
        }
    }
}
