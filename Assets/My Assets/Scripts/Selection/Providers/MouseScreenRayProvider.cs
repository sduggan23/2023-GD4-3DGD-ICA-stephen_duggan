using UnityEngine;

public class MouseScreenRayProvider : MonoBehaviour, IRayProvider
{
    private Camera currentCamera;

    private void Awake()
    {
        currentCamera = Camera.main;
    }

    public Ray CreateRay()
    {
        return currentCamera.ScreenPointToRay(Input.mousePosition);
    }
}