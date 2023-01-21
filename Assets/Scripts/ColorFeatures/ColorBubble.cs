using ColorManRun.Characters;
using ColorManRun.ColorFeatures;
using UnityEngine;
using UnityTools;

namespace ColorManRun.ColorFeatures
{
    public class ColorBubble : MonoBehaviour
    {
        [SerializeField] private GameColor _color;
        [SerializeField] private Material _material;

        public GameColor Color => _color;
        public Material Material => _material;

        public void Burst()
        {
            Destroy(gameObject);

            // Some particle effect or dotween animation
        }
    }
}
