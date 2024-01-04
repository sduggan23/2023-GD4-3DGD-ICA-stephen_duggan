using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractBehaviour : MonoBehaviour
{
    [SerializeField] private UnityEvent interaction;
    private bool isInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interaction.Invoke();
            }
        }
    }
}