using UnityEngine;

namespace CasualSlasher.Control
{
    public class PlayerInput
    {
        public Vector3 GetMovementVector(Joystick joystick)
        {
            var horizontal = joystick.Horizontal;
            var vertical = joystick.Vertical;

            return new(horizontal, 0f, vertical);
        }

        public Vector3 GetMovementVector(Joystick joystick, float speed)
        {
            var horizontal = joystick.Horizontal;
            var vertical = joystick.Vertical;
            return new(
                horizontal * speed,
                0f,
                vertical * speed);
        }
    }
}
