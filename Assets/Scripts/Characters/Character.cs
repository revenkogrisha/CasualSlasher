using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Statistics _stats;
    private bool _isAlive = true;

    public Statistics Stats => _stats;
    public bool IsAlive => _isAlive;

    public event Action OnDamageTaken;
    public event Action OnCharacterDied;

    public void InitStats(StatsConfig statsConfig) => _stats = new(statsConfig);

    public void TakeDamage(float amount)
    {
        var damage = amount - _stats.DamageResistance;
        _stats.HealthAmount -= damage;

        if (_stats.HealthAmount <= 0)
        {
            Die();
            return;
        }

        OnDamageTaken?.Invoke();
    }

    protected virtual void Die()
    {
        _isAlive = false;
        OnCharacterDied?.Invoke();
    }
}
