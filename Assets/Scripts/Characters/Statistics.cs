public struct Statistics
{
    public float HealthAmount;
    public float DamageAmount;
    public float DamageResistance;
    public float MovementSpeed;

    public Statistics(StatsConfig config)
    {
        HealthAmount = config.HealthAmount;
        DamageAmount = config.DamageAmount;
        DamageResistance = config.DamageResistance;
        MovementSpeed = config.MovementSpeed;
    }
}
