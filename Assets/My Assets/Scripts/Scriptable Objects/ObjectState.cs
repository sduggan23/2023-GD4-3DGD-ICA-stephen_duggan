using UnityEngine;

[CreateAssetMenu(fileName = "ObjectState", menuName = "Object State")]
public class ObjectState : ScriptableObject
{
    public bool currentState;

    public void SetNewState(bool newState)
    {
        currentState = newState;
    }
}