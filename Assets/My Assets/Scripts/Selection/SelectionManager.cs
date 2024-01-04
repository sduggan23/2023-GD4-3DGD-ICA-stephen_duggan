using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Allows us to attach multiple responses to a selected object
/// </summary>
public class AdvancedSelectionManager : MonoBehaviour
{
    [SerializeField] private IRayProvider rayProvider;       // Reference to the object providing rays for selection
    [SerializeField] private ISelector selector;            // Reference to the object responsible for object selection
    [SerializeField]
    [RequireInterface(typeof(ISelectionResponse))]
    private List<ScriptableObject> selectionResponses;
     private Transform currentSelection;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        //g Get a ray provider
        rayProvider = GetComponent<IRayProvider>();

        // Get a selector
        selector = GetComponent<ISelector>();
    }

    private void Update()
    {
        // Set de-selected
        if (currentSelection != null)
        {
            // Call the OnDeselect method for each attached response
            foreach (ISelectionResponse response in selectionResponses)
                response.OnDeselect(currentSelection);
        }

        // Create or Get ray
        selector.Check(rayProvider.CreateRay());

        // Get current selection (cast ray, do tag comparison)
        currentSelection = selector.GetSelection();

        //set selected
        if (currentSelection != null)
        {
            // Call the OnSelect method for each attached response
            foreach (ISelectionResponse response in selectionResponses)
                response.OnSelect(currentSelection);
        }
    }
}