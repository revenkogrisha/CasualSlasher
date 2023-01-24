using ColorManRun.ColorFeatures;
using UnityEngine;

namespace ColorManRun.Level
{
    public class ColorPlatform : Platform
    {
        [SerializeField] private MeshRenderer _groundRenderer;
        [SerializeField] private BubblesPairPosition _bubblesPairPosition;

        private GameColor _color;

        public GameColor Color => _color;

        public void SetColor(GameColor color, Material material)
        {
            _color = color;
            _groundRenderer.material = material;
        }

        public Vector3 GetBubblesPosition()
        {
            var position = _bubblesPairPosition.transform.position;
            return position;
        }
    }
}
