using UnityEngine.AI;

namespace CasualSlasher.Generators
{
    public interface INavMeshSurfaceGenerator
    {
        public void GenerateSurface(NavMeshSurface surface);
    }
}
