using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IItem item = other.GetComponent<IItem>();

        if (item != null)
        {
            item.Collect();
        }
    }
}