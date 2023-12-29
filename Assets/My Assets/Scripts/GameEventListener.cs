using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField]
    private string description;

    [SerializeField]
    [Tooltip("Specify the game event (scriptable object) which will raise the event")]
    private GameEvent Event;        // GameEvent this GameEventListener will subscribe to

    [SerializeField]
    private UnityEvent Response;    // UnityEvent response that will be invoked when the GameEvent raises this GameEventListener

    // Register the GameEvent to the GameEventListener when this GameObject is enabled
    private void OnEnable() => Event.RegisterListener(this);

    // Unregister the GameEvent from the GameEventListener when this GameObject is disabled
    private void OnDisable() => Event.UnregisterListener(this);
    // Call when a GameEvent is raised causing the GameEventListener to invoke the UnityEvent
    public virtual void OnEventRaised() => Response?.Invoke();
}