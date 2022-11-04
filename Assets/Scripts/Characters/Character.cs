using UnityEngine;

public class Character : MonoBehaviour, IStatisticsCarrier
{
    private Statistics _stats;

    public Statistics Stats => _stats;

    public void InitStats(StatsConfig enemyStatsConfig) => _stats = new(enemyStatsConfig);

    private void TakeDamageAndCheckHealth(float amount)
    {
        var damage = amount - _stats.DamageResistance;
        _stats.HealthAmount -= damage;

        if(_stats.HealthAmount <= 0)
            Die();
    }

    private void Die()
    {
        // TODO: Implement Die logic
        Destroy(gameObject);
    }
}
