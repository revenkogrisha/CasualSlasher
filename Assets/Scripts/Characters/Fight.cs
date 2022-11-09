using System.Collections;
using UnityEngine;

public class Fight : MonoBehaviour
{
    [SerializeField] private float _damage = 2f;
    [SerializeField] private float _hitCooldown = 2f;
    [SerializeField] private float _hitRadius;
    [SerializeField] private Transform _hitSphere;
    [SerializeField] private LayerMask _hitLayer;

    private bool _canHit = true;

    #region MonoBehaviour

    private void OnTriggerStay(Collider other) => TryHit();

    #endregion

    public void TryHit()
    {
        if (!_canHit)
            return;

        var hitted = Physics.OverlapSphere(_hitSphere.position, _hitRadius, _hitLayer);

        Character character;
        foreach (var item in hitted)
        {
            character = item.GetComponentInParent<Character>();
            if (character)
            {
                Hit(character);
                StartCoroutine(StartHitCooldown());
            }
        }

    }

    private void Hit(Character character)
    {
        character.TakeDamage(_damage);
    }

    private IEnumerator StartHitCooldown()
    {
        _canHit = false;

        yield return new WaitForSeconds(_hitCooldown);

        _canHit = true;
    }
}
