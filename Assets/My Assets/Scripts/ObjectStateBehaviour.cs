using UnityEngine;

public class ObjectStateController : MonoBehaviour
{
    public ObjectState objectState; // Reference to the ScriptableObject

    public GameObject targetObject; // The GameObject whose state will be modified

    private void Start()
    {
        // Initialize the object state based on the ScriptableObject
        if (targetObject != null && objectState != null)
        {
            // Example: Set the initial state of the GameObject based on the ScriptableObject
           //etObjectState(objectState.currentState);
        }
    }

    public void SetObjectState(bool newState)
    {
        if (targetObject != null)
        {
            // Modify the state of the GameObject based on the newState
            // Example: Activate/deactivate a particle system based on the state


            // Update the ScriptableObject with the new state
            if (objectState != null)
            {

                if (!newState)
                {
                    if (GameManager.instance.itemCount >= 3)
                    {
                        newState = true;
                        Debug.Log("fire behaviour item count: " + GameManager.instance.itemCount);
                        objectState.SetNewState(newState);
                        targetObject.gameObject.SetActive(true);
                        Debug.Log("Changed state");
                        GameManager.instance.GameComplete();
                    }
                }
            }

        }
    }
}
