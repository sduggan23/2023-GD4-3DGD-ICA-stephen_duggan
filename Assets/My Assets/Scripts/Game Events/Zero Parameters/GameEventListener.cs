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

    private void OnEnable() => Event.RegisterListener(this);

    private void OnDisable() => Event.UnregisterListener(this);

    public virtual void OnEventRaised() => Response?.Invoke();
}