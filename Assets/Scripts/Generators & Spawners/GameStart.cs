using CasualSlasher.Characters;
using CasualSlasher.Control;
using UnityEngine;
using UnityEngine.AI;

namespace CasualSlasher.Generators
{
    public class GameStart : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private CharacterSpawner _characterSpawner;

        [Header("Level")]
        [SerializeField] private NavMeshSurface _navSurface;

        private INavMeshSurfaceGenerator _navSurfaceGenerator;

        private void Awake()
        {
            _navSurfaceGenerator = new NavMeshSurfaceGenerator();
        }

        private void Start()
        {
            _navSurfaceGenerator.GenerateSurface(_navSurface);
        }
    }
}