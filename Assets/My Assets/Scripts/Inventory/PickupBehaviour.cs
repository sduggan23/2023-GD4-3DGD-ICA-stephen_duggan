using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    [SerializeField] private string targetTag = "Item";
    [SerializeField] private ItemDataGameEvent OnPickup;
    public GameObject targetObject;
    private bool isInRange;

    private void Awake()
    {
        targetTag.Trim();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            targetObject = other.gameObject;
            isInRange = true;
            Debug.Log("Is in Range");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            targetObject = null;
            isInRange = false;
            Debug.Log("Is not in Range");
        }
    }

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                HandlePickup();
            }
        }
    }

    public void HandlePickup()
    {
        //get item data
        var behaviour = targetObject.gameObject.GetComponent<ItemDataBehaviour>();

        if (behaviour != null)
        {
            Debug.Log("On pickup Event Raised");
            var itemData = behaviour.ItemData;
            //raise the event
            OnPickup?.Raise(itemData);
            //play the sound
            AudioSource.PlayClipAtPoint(itemData.PickupClip,targetObject.gameObject.transform.position);
            StartCoroutine(DestroyObject());

        }
    }
    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(targetObject.gameObject);
    }
}