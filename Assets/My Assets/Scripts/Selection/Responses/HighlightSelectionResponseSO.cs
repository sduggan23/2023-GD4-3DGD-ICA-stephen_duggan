using System;
using UnityEngine;

/// <summary>
/// Sets a highlight material (based on a user-defined material) on selection of an appropriate game object
/// </summary>
[CreateAssetMenu(fileName = "HighlightSelectionResponseSO", menuName = "Responses/Highlight")]
[Serializable]
public class HighlightSelectionResponseSO : ScriptableObject, ISelectionResponse // Implements the ISelectionResponse interface to handle object selection and deselection
{
    [SerializeField]
    [Tooltip("Set selected (highlighted) material for game object")]
    private Material selectedMaterial;
    private Material currentOriginalMaterial;

    public void OnDeselect(Transform selection)
    {
        var renderer = selection.GetComponent<Renderer>();
        // Check if the renderer exists and the original material is available
        if (renderer != null && currentOriginalMaterial != null)
            renderer.material = currentOriginalMaterial;
    }

    public void OnSelect(Transform selection)
    {
        // Get the object's renderer component
        var renderer = selection.GetComponent<Renderer>();
        if (renderer != null)
        {
            // Set the current material as the original material
            currentOriginalMaterial = renderer.material;
            // Apply the selected material to highlight the object
            renderer.material = selectedMaterial;
        }
    }
}