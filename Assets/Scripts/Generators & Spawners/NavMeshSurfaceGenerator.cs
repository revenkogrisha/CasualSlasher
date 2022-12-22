using UnityEngine.AI;

namespace SaveTheGuy.Generators
{
    public class NavMeshSurfaceGenerator : INavMeshSurfaceGenerator
    {
        public void GenerateSurface(NavMeshSurface surface) => surface.BuildNavMesh();
    }
}
