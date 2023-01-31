using UnityEngine;

namespace ColorManRun.ColorFeatures
{
    public class ColorBubblesPair : MonoBehaviour
    {
        private ColorBubble _firstBubble;
        private ColorBubble _secondBubble;
        private readonly Vector3 _firstBubbleOffset = new(1f, 0f, 0f);
        private readonly Vector3 _secondBubbleOffset = new(-1f, 0f, 0f);

        public void Init(ColorBubble firstBubble, ColorBubble secondBubble)
        {
            if (_firstBubble != null || _secondBubble != null)
                throw new System.Exception("Secondary init is not permitted");

            _firstBubble = firstBubble;
            _secondBubble = secondBubble;
        }

        private void SpawnBubblesPair()
        {
            var firstBubble = SpawnBubbleWithinPair(_firstBubble);
            var secondBubble = SpawnBubbleWithinPair(_secondBubble);

            var firstBubbleTransform = firstBubble.transform;
            firstBubbleTransform.position += _firstBubbleOffset;

            var secondBubbleTransform = secondBubble.transform;
            secondBubbleTransform.position += _secondBubbleOffset;
        }

        private ColorBubble SpawnBubbleWithinPair(ColorBubble bubblePrefab)
        {
            var bubble =
                Instantiate(bubblePrefab, transform.position, Quaternion.identity);

            var bubbleTransform = bubble.transform;
            bubbleTransform.SetParent(transform);
            return bubble;
        }
    }
}
