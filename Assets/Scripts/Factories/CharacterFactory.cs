using UnityEngine;

public class CharacterFactory : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private StatsConfig _statsConfig;
    [SerializeField] private Character _characterPrefab;

    public Character GetEnemy()
    {
        var character = _characterPrefab;
        character = SetupStats(character, _statsConfig);
        character = TrySetupMovement(character, _target);
        return character;
    }

    private Character SetupStats(Character character, StatsConfig config)
    {
        character.InitStats(config);
        return character;
    }

    private Character TrySetupMovement(Character character, Transform target)
    {
        var agentMovement = character.GetComponent<AgentMovement>();
        if (!agentMovement)
        {
            Debug.Log("AgentMovement lost");
            return character;
        }

        agentMovement.SetTarget(target);
        return character;
    }
}
