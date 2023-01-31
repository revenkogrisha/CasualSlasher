using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorManRun.ColorFeatures
{
    public class ColorBubble : MonoBehaviour
    {
        [SerializeField] private GameColor _color;
        [SerializeField] private Material _material;

        public GameColor Color => _color;
        public Material Material => _material;
    }
}
