using System;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [Header("Health UI Display")]
    [SerializeField] private bool _displayHealth;
    [SerializeField] private Slider _healthSlider;

    private Statistics _stats;
    private bool _isAlive = true;

    public Statistics Stats => _stats;
    public bool IsAlive => _isAlive;

    public event Action OnDamageTaken;
    public event Action OnCharacterDied;
    public event Action<float> OnHealthChanged;

    public void InitStats(StatsConfig statsConfig) => _stats = new(statsConfig);

    public void TakeDamage(float amount)
    {
        var damage = amount - _stats.DamageResistance;
        _stats.HealthAmount -= damage;

        OnHealthChanged?.Invoke(_stats.HealthAmount);

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
