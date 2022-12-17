using SaveTheGuy.Characters;
using SaveTheGuy.Control;
using UnityEngine;
using UnityEngine.AI;

namespace SaveTheGuy.Level
{
    public class GameFlow : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private PlatformGenerator _platformGenerator;
        [SerializeField] private CharacterSpawner _characterSpawner;

        [Header("Player")]
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Camera _camera;

        [Header("Prefabs")]
        [SerializeField] private PlayerCharacter _playerPrefab;

        [Header("Level")]
        [SerializeField] private NavMeshSurface _navSurface;
        [SerializeField] private Vector3 _playerSpawnPosition = Vector3.forward;
        
        private OrbitCamera _orbitCamera;
        private LevelGenerator _levelGenerator;

        #region MonoBehaviour

        private void Awake()
        {
            _levelGenerator = new(
                _platformGenerator,
                _characterSpawner, 
                _playerPrefab);
        }

        private void OnEnable()
        {
            _levelGenerator.OnPlayerSpawned += InitCamera;
        }
    
        private void OnDisable()
        {
            _levelGenerator.OnPlayerSpawned -= InitCamera;
        }

        private void Start()
        {
            GenerateLevel(_levelGenerator);
        }

        private void LateUpdate()
        {
            _orbitCamera.TryApplyCameraTransform();
        }

        #endregion

        private void InitCamera(PlayerCharacter player)
        {
            var playerTransform = player.transform;
            var playerPosition = playerTransform.position;
            _orbitCamera = new(_camera, playerTransform, playerPosition);
        }

        private void GenerateLevel(LevelGenerator generator)
        {
            generator.GenerateLevel(
                _navSurface,
                _playerSpawnPosition);
        }
    }
}