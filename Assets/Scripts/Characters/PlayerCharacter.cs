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

        private void OnTriggerEnter(Collider other)
        {
            Tools.InvokeIfNotNull<ColorBubble>(other, TakeColorFromBubble);
        }

        #endregion

        public void TakeColorFromBubble(ColorBubble bubble)
        {
            _color = bubble.Color;
            _renderer.material = bubble.Material;

            bubble.Burst();
        }
    }
}
