public struct EnemyStats
{
    public float HealthAmount;
    public float DamageAmount;
    public float DamageResistance;
    public float MovementSpeed;

    public EnemyStats(EnemyStatsConfig config)
    {
        HealthAmount = config.HealthAmount;
        DamageAmount = config.DamageAmount;
        DamageResistance = config.DamageResistance;
        MovementSpeed = config.MovementSpeed;
    }
}
