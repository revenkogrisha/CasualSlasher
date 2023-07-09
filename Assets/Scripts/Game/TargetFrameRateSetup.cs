using UnityEngine;

public class TargetFrameRateSetup : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}