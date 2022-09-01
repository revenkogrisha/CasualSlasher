using UnityEngine;

[RequireComponent(typeof(RelativeMovement))]
[RequireComponent(typeof(RelativeJump))]
public class CharacterAnimator : MonoBehaviour
{
    public const string Running = nameof(Running);
    public const string Jumped = nameof(Jumped);

    [SerializeField] private Animator _animator;

    private RelativeMovement _relativeMovement;
    private RelativeJump _relativeJump;

    private void Awake()
    {
        _relativeJump = GetComponent<RelativeJump>();
        _relativeMovement = GetComponent<RelativeMovement>();
    }

    private void OnEnable()
    {
        _relativeJump.OnJumpStarted += EnableJumping;
        _relativeJump.OnJumpEnded += DisableJumping;
        _relativeMovement.OnRunStarted += EnableRunning;
        _relativeMovement.OnRunEnded += DisableRunning;
    }

    private void OnDisable()
    {
        _relativeJump.OnJumpStarted -= EnableJumping;
        _relativeJump.OnJumpEnded -= DisableJumping;
        _relativeMovement.OnRunStarted -= EnableRunning;
        _relativeMovement.OnRunEnded -= DisableRunning;
    }

    private void EnableRunning()
    {
        _animator.SetBool(Running, true);
    }

    private void DisableRunning()
    {
        _animator.SetBool(Running, false);
    }
    
    private void EnableJumping()
    {
        _animator.SetBool(Jumped, true);
    }

    private void DisableJumping()
    {
        _animator.SetBool(Jumped, false);
    }
}