using System.Collections;
using UnityEngine;

public class Fight : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private CharacterAnimator _animator;
    [SerializeField] private float _hitCooldown = 2f;
    [SerializeField] private float _hitRadius;
    [SerializeField] private Transform _hitSphere;
    [SerializeField] private LayerMask _hitLayer;

    private bool _canHit = true;

    #region MonoBehaviour

    private void OnEnable()
    {
        _character.OnDamageTaken += GetStun;
    }
    
    private void OnDisable()
    {
        _character.OnDamageTaken -= GetStun;
    }

    private void OnTriggerStay(Collider other) => TryHit(_character.Stats.DamageAmount);

    private void OnTriggerExit(Collider other) => _animator.EndHitting();

    #endregion

    public void TryHit(float damage)
    {
        if (!_canHit)
            return;

        var hitted = Physics.OverlapSphere(_hitSphere.position, _hitRadius, _hitLayer);

        Character character;
        foreach (var item in hitted)
        {
            character = item.GetComponentInParent<Character>();
            if (character == null)
                return;

            if (character.IsAlive == true)
            {
                _animator.PerformHitting();
                character.TakeDamage(damage);
                StartCoroutine(StartHitCooldown(_hitCooldown));
            }

            if (character.IsAlive == false)
                _animator.EndHitting();
        }
    }

    private void GetStun()
    {
        var stats = _character.Stats;
        var stunDuration = stats.StunDuration;
        StartCoroutine(StartHitCooldown(stunDuration));
    }

    private IEnumerator StartHitCooldown(float cooldown)
    {
        _canHit = false;

        yield return new WaitForSeconds(cooldown);

        _canHit = true;
    }
}
