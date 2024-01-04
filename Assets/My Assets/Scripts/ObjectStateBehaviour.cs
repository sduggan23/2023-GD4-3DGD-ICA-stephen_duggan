using UnityEngine;

public class ObjectStateBehaviour : MonoBehaviour
{
    [SerializeField] private ObjectState objectState; // Reference to the ScriptableObject
    [SerializeField] private GameObject targetObject; // The GameObject whose state will be modified

    private void Start()
    {
        // Initialize the object state based on the ScriptableObject
        if (targetObject != null && objectState != null)
        {
            // Set the initial state of the GameObject based on the ScriptableObject
           SetObjectState(objectState.currentState);
        }
    }

    public bool SetObjectState(bool newState)
    {
        if (targetObject != null)
        {
            // Update the ScriptableObject with the new state
            if (objectState != null)
            {
                if (GameManager.instance.itemCount >= 3)
                {
                    newState = true;
                    objectState.SetNewState(newState);
                    targetObject.gameObject.SetActive(true);
                    GameManager.instance.PrepareGameComplete();
                }
            }
        }
        return newState;
    }
}
