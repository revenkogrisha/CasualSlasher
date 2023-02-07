using ColorManRun.ColorFeatures;
using UnityEngine;
using UnityTools;

namespace ColorManRun.Characters
{
    public class PlayerCharacter : CharacterAwakeInit
    {
        [SerializeField] private Renderer _renderer;

        private GameColor _color;

        #region MonoBehaviour

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            var other = hit.collider;
            Tools.InvokeIfNotNullInParent<ColorBubble>(other, TryTakeBubbleColor);
        }

        #endregion

        public void TryTakeBubbleColor(ColorBubble bubble)
        {
            _color = bubble.Color;
            _renderer.material = bubble.Material;
        }
    }
}
