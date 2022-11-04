using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Config", menuName = "Configs/EnemyConfig")]
public class EnemyStatsConfig : ScriptableObject
{
    [SerializeField] private float _healthAmount;
    [SerializeField] private float _damageAmount;
    [SerializeField] private float _damageResistance;
    [SerializeField] private float _movementSpeed;

    public float HealthAmount => _healthAmount;
    public float DamageAmount => _damageAmount;
    public float DamageResistance => _damageResistance;
    public float MovementSpeed => _movementSpeed;
}
