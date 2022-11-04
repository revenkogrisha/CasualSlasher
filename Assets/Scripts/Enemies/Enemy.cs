using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyStats _stats;

    public EnemyStats Stats => _stats;

    public void InitStats(EnemyStatsConfig enemyStatsConfig) => _stats = new(enemyStatsConfig);

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
