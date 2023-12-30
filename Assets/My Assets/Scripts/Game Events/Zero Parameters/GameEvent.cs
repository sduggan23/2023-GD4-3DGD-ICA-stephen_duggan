using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameEvent", menuName = "Game Event")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();  // A list of GameEventListeners that will subscribe to your GameEvent

    [ContextMenu("Raise Event")]
    // Invoke all of the subscribers of a GameEvent
    public virtual void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)          // The last GameEventListener to be subscribed will be the first to get invoked (last in, first out)
        {
            listeners[i].OnEventRaised();
        }
    }

    // Allow GameEventListeners to subscribe to this GameEvent
    public void RegisterListener(GameEventListener listener)
    {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }

    // Allow GameEventListeners to unsubscribe to this GameEvent
    public void UnregisterListener(GameEventListener listener)  
    {
        if (listeners.Contains(listener))
            listeners.Remove(listener);
    }
}