using UnityEngine;

namespace SaveTheGuy.Control
{
    public class PlayerInput
    {
        public Vector3 GetMovementVector()
        {
            var horizontal = Input.GetAxis(Axis.MouseX);
            return new(horizontal, 0f, 1f);
        }

        public Vector3 GetMovementVector(float forwardSpeed, float horizontalSpeed)
        {
            var horizontal = Input.GetAxis(Axis.MouseX);
            return new(
                horizontal * horizontalSpeed,
                0f,
                forwardSpeed);
        }
    }
}
