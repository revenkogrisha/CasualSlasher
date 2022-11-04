using UnityEngine;
using UnityEngine.AI;

public class NavMeshSurfaceGenerator : MonoBehaviour
{
    [SerializeField] private NavMeshSurface _navMeshSurface;

    #region MonoBehaviour

    private void Start() => GenerateNavMeshSurface(_navMeshSurface);

    #endregion

    private void GenerateNavMeshSurface(NavMeshSurface surface) => surface.BuildNavMesh();
}
