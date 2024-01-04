using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameEvent itemObject;
    [SerializeField] private GameObject image;
    private bool isInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            image.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            image.SetActive(false);
        }
    }

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                itemObject.Raise();
                Debug.Log(itemObject + " Event Raised");
            }
        }
    }
}