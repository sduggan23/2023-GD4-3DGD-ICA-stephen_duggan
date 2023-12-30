using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IItem
{
    [SerializeField]
    private GameEvent OnItemCollected;
    public void Collect()
    {
        Debug.Log("Collected an item");
        OnItemCollected.Raise();
        Destroy(gameObject);
    }

    //[SerializeField]
    //private GameEvent itemObject;
    //private bool isSelected;

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        if (isSelected == false)
    //        {
    //            ItemEvent();
    //        }
    //    }
    //}

    //public void ItemEvent()
    //{
    //    itemObject.Raise();
    //    isSelected = true;
    //    Vector3 pos = transform.position;
    //    pos.y = 10f;
    //    transform.position = pos;
    //    Debug.Log(itemObject + " Event Raised");
    //}
}
