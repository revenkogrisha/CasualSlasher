using UnityEngine;

[RequireComponent(typeof(RelativeMovement))]
public class CharacterAnimator : MonoBehaviour
{
    public const string Running = nameof(Running);
    public const string Jumped = nameof(Jumped);

    [SerializeField] private Animator _animator;

    private RelativeMovement _relativeMovement;

    #region MonoBehaviour

    private void Awake()
    {
        _relativeMovement = GetComponent<RelativeMovement>();
    }

    private void OnEnable()
    {
        _relativeMovement.OnRunStarted += EnableRunning;
        _relativeMovement.OnRunEnded += DisableRunning;
    }

    private void OnDisable()
    {
        _relativeMovement.OnRunStarted -= EnableRunning;
        _relativeMovement.OnRunEnded -= DisableRunning;
    }

    #endregion

    private void EnableRunning()
    {
        _animator.SetBool(Running, true);
    }

    private void DisableRunning()
    {
        _animator.SetBool(Running, false);
    }
}