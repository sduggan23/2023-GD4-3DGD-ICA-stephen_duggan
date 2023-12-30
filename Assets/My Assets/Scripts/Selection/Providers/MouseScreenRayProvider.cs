using UnityEngine;

public class MouseScreenRayProvider : MonoBehaviour, IRayProvider
{
    [Tooltip("Specify the camera to use to create the ray from camera to mouse")]
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