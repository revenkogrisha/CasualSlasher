using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public void Spawn(CharacterAwakeInit characterPrefab, Vector3 position) =>
        Instantiate(characterPrefab, position, Quaternion.identity);

    public void Spawn(Character characterPrefab, StatsConfig config, Vector3 position)
    {
        var character = Instantiate(characterPrefab, position, Quaternion.identity);

        var factory = new CharacterFactory();
        factory.InitStats(character, config);
    }
}
