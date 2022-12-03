using UnityEngine;
using UnityEngine.AI;

public class NavMeshSurfaceGenerator : MonoBehaviour
{
    public void GenerateNavMeshSurface(NavMeshSurface surface) => surface.BuildNavMesh();
}
