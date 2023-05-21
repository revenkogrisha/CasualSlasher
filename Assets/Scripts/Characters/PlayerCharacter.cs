using CasualSlasher.ColorFeatures;
using UnityEngine;
using UnityTools;

namespace CasualSlasher.Characters
{
    public class PlayerCharacter : CharacterAwakeInit
    {
        [SerializeField] private ParticleSystem _deathParticles;
        [SerializeField] private Renderer _renderer;

        private GameColor _color;

        #region MonoBehaviour

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            var other = hit.collider;
            Tools.InvokeIfNotNullInParent<ColorBubble>(other, TryTakeBubbleColor);

            Tools.InvokeIfNotNullInParent<IColorObstacle>(other, CompareColors);
        }

        #endregion

        public void TryTakeBubbleColor(ColorBubble bubble)
        {
            _color = bubble.Color;
            _renderer.material = bubble.Material;

            bubble.Burst();
        }

        private void CompareColors(IColorObstacle obstacle)
        {
            var otherColor = obstacle.Color;

            var areColorMatch = otherColor.Equals(_color);
            if (areColorMatch)
                return;

            InvokeDeath();
        }

        private void InvokeDeath()
        {
            // Die
        }
    }
}