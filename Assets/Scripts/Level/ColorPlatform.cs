using ColorManRun.ColorFeatures;
using UnityEngine;

namespace ColorManRun.Level
{
    public class ColorPlatform : Platform
    {
        [SerializeField] private MeshRenderer _groundRenderer;
        [SerializeField] private Transform _bubblesPairRoot;

        private GameColor _color;

        public GameColor Color => _color;

        public void SetColor(GameColor color, Material material)
        {
            _color = color;
            _groundRenderer.material = material;
        }

        public void SetBubblesPair(ColorBubblesPair colorBubblesPair)
        {
            var bubblesTransform = colorBubblesPair.transform;
            bubblesTransform.position = _bubblesPairRoot.transform.position;
        }
    }
}
