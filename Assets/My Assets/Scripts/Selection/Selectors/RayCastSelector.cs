using UnityEngine;

public class RayCastSelector : MonoBehaviour, ISelector
{
    [SerializeField]
    [Tooltip("Define the tag used by selectable objects")]
    private string selectableTag = "Item";

    [SerializeField]
    [Tooltip("Define the layer to which selectable objects belong")]
    private LayerMask layerMask;

    [SerializeField]
    [Range(0.01f, 500)]
    [Tooltip("Define the max distance(metres) over which to allow selection")]
    private float maxDistance = 50;
    private Transform selection;
    private RaycastHit hitInfo;

    // Get the currently selected object's transform
    public Transform GetSelection()
    {
        return selection;
    }

    // Get information about the raycast hit
    public RaycastHit GetHitInfo()
    {
        return hitInfo;
    }

    public void Check(Ray ray)
    {
        selection = null;
        // RayCast check for hits on objects within the distance and layer mask
        if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask.value))
        {
            // Get the transform of the hit object
            var currentSelection = hitInfo.transform;

            if (currentSelection.CompareTag(selectableTag))
                selection = currentSelection;
        }
    }
}