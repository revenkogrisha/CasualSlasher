using CasualSlasher.Characters;
using CasualSlasher.Level;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace CasualSlasher.Generators
{
    public class LevelGenerator
    {
        private INavMeshSurfaceGenerator _navGenerator;
        private CharacterSpawner _characterSpawner;
        private PlayerCharacter _playerPrefab;

        public event Action<PlayerCharacter> OnPlayerSpawned;

        public LevelGenerator(
            CharacterSpawner characterSpawner, 
            PlayerCharacter playerPrefab) // ***
        {
            _navGenerator = new NavMeshSurfaceGenerator();
            _characterSpawner = characterSpawner;
            _playerPrefab = playerPrefab;
        }

        public void GenerateLevel(
            NavMeshSurface navSurface,
            Vector3 playerSpawnPosition)
        {

        }
    }
}
