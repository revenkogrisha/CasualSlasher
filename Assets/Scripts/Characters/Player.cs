using System;

public class Player : CharacterAwakeInit
{
    public event Action OnPlayerDied;

    protected override void Die()
    {
        print("Game Over!");
        OnPlayerDied?.Invoke();
    }
}
