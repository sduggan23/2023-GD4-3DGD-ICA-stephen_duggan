using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    public GameObject targetObject;
    [SerializeField] private string targetTag = "Item";
    [SerializeField] private ItemDataGameEvent OnPickup;
    private bool isInRange;

    private void Awake()
    {
        targetTag.Trim();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            // Set the collided object as the target object
            targetObject = other.gameObject; 
            isInRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            isInRange = false;
            // Reset the target object when player exits range
            targetObject = null;
        }
    }

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (targetObject == null)
                {
                    return;
                }
                HandlePickup();
            }
        }
    }

    public void HandlePickup()
    {
        // Get item data from the target object's ItemDataBehaviour component
        var behaviour = targetObject.gameObject.GetComponent<ItemDataBehaviour>();

        if (behaviour != null)
        {
            // Get the item data
            var itemData = behaviour.ItemData;
            // Raise the event, passing the item data
            OnPickup?.Raise(itemData);
            // Play the sound
            AudioSource.PlayClipAtPoint(itemData.PickupClip,targetObject.gameObject.transform.position);
            // Destroy the target object after a delay
            StartCoroutine(RunDelayedEvent());

        }
    }
    // Coroutine to delay destroying the target object after pickup
    private IEnumerator RunDelayedEvent()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(targetObject.gameObject);
    }
}