using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public const string Running = nameof(Running);

    [SerializeField] private Animator _animator;

    public void EnableRunning()
    {
        _animator.SetBool(Running, true);
    }

    public void DisableRunning()
    {
        _animator.SetBool(Running, false);
    }
}