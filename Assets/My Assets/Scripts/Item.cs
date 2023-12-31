using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private GameEvent itemObject;
    private bool isSelected;

    public void ItemEvent()
    {
        //itemObject.Raise();
        //isSelected = true;
        //Vector3 pos = transform.position;
        //pos.y = 10f;
        //transform.position = pos;
        //Debug.Log(" Event Raised");
    }
    public void OnTriggerEnter(Collider collision)
    {
        //isSelected = true;
        //Vector3 pos = transform.position;
        //pos.y = 10f;
        //transform.position = pos;
        Debug.Log(" Event Raised");
        itemObject.Raise();
    }
}
