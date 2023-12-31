using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TeleportResponseSO", menuName = "Responses/Teleport")]
[Serializable]
public class TeleportResponseSO : ScriptableObject, ISelectionResponse
{
    private Transform currentOriginalTransform;
    public void OnDeselect(Transform selection)
    {
        var currentPos = selection.GetComponent<Transform>();
        //we can use c# 7.0 syntax -https://www.thomasclaudiushuber.com/2020/03/12/c-different-ways-to-check-for-null/"/>
        if (currentPos != null && currentOriginalTransform != null)
            currentPos = currentOriginalTransform;
    }

    public void OnSelect(Transform selection)
    {
        Vector3 pos = selection.position;
        pos.y = 10f;
        selection.transform.position = pos;

        var item = selection.GetComponent<Item>();
        if (item != null)
        {
            item.ItemEvent();
        }
    }
}
