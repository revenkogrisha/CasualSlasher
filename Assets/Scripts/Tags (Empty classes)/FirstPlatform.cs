using ColorManRun.ColorFeatures;
using UnityEngine;

namespace ColorManRun.Level
{
    public class FirstPlatform : Platform
    {
        [SerializeField] private ColorBubblesRoot _bubblesTrioRoot;

        public void SetBubblesTrio(ColorBubblesTrio colorBubblesTrio)
        {
            var rootTransform = _bubblesTrioRoot.transform;
            var pairPosition = rootTransform.position;
            var bubblesTransform = colorBubblesTrio.transform;

            bubblesTransform.position = pairPosition;
        }
    }
}
