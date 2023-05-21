using UnityEngine.AI;

namespace CasualSlasher.Generators
{
    public class NavMeshSurfaceGenerator : INavMeshSurfaceGenerator
    {
        public void GenerateSurface(NavMeshSurface surface) => surface.BuildNavMesh();
    }
}
