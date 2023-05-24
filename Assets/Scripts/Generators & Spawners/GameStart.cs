using CasualSlasher.Characters;
using CasualSlasher.Control;
using UnityEngine;
using UnityEngine.AI;

namespace CasualSlasher.Generators
{
    public class GameStart : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private PlatformGenerator _platformGenerator;
        [SerializeField] private CharacterSpawner _characterSpawner;

        [Header("Player")]
        [SerializeField] private Joystick _joystick;
        [SerializeField] private OrbitCamera _orbitCamera;

        [Header("Prefabs")]
        [SerializeField] private PlayerCharacter _playerPrefab;

        [Header("Level")]
        [SerializeField] private NavMeshSurface _navSurface;
        [SerializeField] private Vector3 _playerSpawnPosition = Vector3.forward;
        
        private LevelGenerator _levelGenerator;

        private void GenerateLevel(LevelGenerator generator)
        {
            generator.GenerateLevel(
                _navSurface,
                _playerSpawnPosition);
        }
    }
}