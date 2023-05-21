using CasualSlasher.Characters;
using UnityEngine;
using UnityTools;

namespace CasualSlasher.Level
{
    public class Finish : AgentTarget
    {
        #region MonoBehaviour

        private void OnTriggerEnter(Collider other)
        {
            Tools.InvokeIfNotNull<PlayerCharacter>(other, InvokeGameOver);
        }

        #endregion

        private void InvokeGameOver()
        {
            print("Finished!");
            // There should be game over logic...
            // Also some UI handling class needs to be subscribed to game over event in order to show UI
        }
    }
}