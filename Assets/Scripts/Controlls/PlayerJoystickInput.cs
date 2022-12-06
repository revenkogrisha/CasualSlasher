using UnityEngine;

public class PlayerJoystickInput : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private IMoveable[] _moveables;

    private void Update() => Move(_moveables);

    private void Move(IMoveable[] moveables)
    {
        var movement = GetMovementVector();
        foreach (var moveable in moveables)
            moveable.TryMove(movement);
    }

    private Vector3 GetMovementVector() => new Vector3(
        _joystick.Horizontal,
        0,
        _joystick.Vertical);
}
