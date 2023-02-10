using ColorManRun.ColorFeatures;
using UnityEngine;

namespace ColorManRun.Level
{
    public class ColorPlatform : Platform, IColorHandler
    {
        [SerializeField] private MeshRenderer _groundRenderer;
        [SerializeField] private ColorBubblesRoot _bubblesPairRoot;

        private GameColor _color;

        public GameColor Color => _color;

        public void SetColor(GameColor color, Material material)
        {
            _color = color;
            _groundRenderer.material = material;
        }
        
        public void SetBubblesPair(ColorBubblesPair colorBubblesPair)
        {
            var rootTransform = _bubblesPairRoot.transform;
            var pairPosition = rootTransform.position;
            var bubblesTransform = colorBubblesPair.transform;

            bubblesTransform.position = pairPosition;
        }
    }
}