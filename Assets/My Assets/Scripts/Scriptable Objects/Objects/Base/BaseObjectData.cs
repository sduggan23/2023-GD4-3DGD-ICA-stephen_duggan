using Sirenix.OdinInspector;
using UnityEngine;

public abstract class BaseObjectData : ScriptableGameObject
{
    //[Tooltip("Specify the type of this object (e.g. equipment, food, weapon)")]
    // [DynamicTooltip()]
    [EnumPaging]
    public ItemType Type;
}