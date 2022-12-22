using UnityEngine.AI;

namespace SaveTheGuy.Generators
{
    public interface INavMeshSurfaceGenerator
    {
        public void GenerateSurface(NavMeshSurface surface);
    }
}
