using UnityEngine;

namespace CasualSlasher.Level
{
    public class FinishPlatform : Platform
    {
        [SerializeField] private Finish _finish;

        public Finish Finish => _finish;
    }
}
