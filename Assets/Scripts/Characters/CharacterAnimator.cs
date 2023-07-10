using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public const string Running = nameof(Running);
    public const string Hitting = nameof(Hitting);

    [SerializeField] private Animator _animator;

    public void EnableRunning()
    {
        _animator.SetBool(Running, true);
    }

    public void DisableRunning()
    {
        _animator.SetBool(Running, false);
    }

    public void PerformHitting()
    {
        _animator.SetBool(Hitting, true);
    }

    public void EndHitting()
    {
        _animator.SetBool(Hitting, false);
    }
}