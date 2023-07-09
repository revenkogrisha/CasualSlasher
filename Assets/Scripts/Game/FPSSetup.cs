using UnityEngine;

public class FPSSetup : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}