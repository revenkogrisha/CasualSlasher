using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private Transform _enemyTarget;
    [SerializeField] private EnemyStatsConfig _enemyConfig;
    [SerializeField] private Enemy _enemyPrefab;

    public Enemy GetEnemy()
    {
        var enemy = _enemyPrefab;
        enemy = SetupEnemyStats(enemy, _enemyConfig);
        enemy = SetupEnemyMovement(enemy, _enemyTarget);
        return enemy;
    }

    private Enemy SetupEnemyStats(Enemy enemy, EnemyStatsConfig config)
    {
        enemy.InitStats(config);
        return enemy;
    }

    private Enemy SetupEnemyMovement(Enemy enemy, Transform target)
    {
        var enemyMovement = enemy.GetComponent<EnemyMovement>();
        enemyMovement.SetTarget(target);
        return enemy;
    }
}
