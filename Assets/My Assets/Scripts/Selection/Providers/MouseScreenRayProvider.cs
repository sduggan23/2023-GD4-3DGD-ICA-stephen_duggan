using UnityEngine;

public class MouseScreenRayProvider : MonoBehaviour, IRayProvider // Implements the IRayProvider interface to create a Ray from the mouse screen position
{
    private Camera currentCamera;

    private void Awake()
    {
        currentCamera = Camera.main;
    }

    // Method required by the IRayProvider interface
    public Ray CreateRay()
    {
        // Ray from the mouse position on the screen using the current camera
        return currentCamera.ScreenPointToRay(Input.mousePosition);
    }
}