using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField]
    protected string description;

    [SerializeField]
    [Tooltip("Specify the game event (scriptable object) which will raise the event")]
    protected GameEvent Event;

    [SerializeField]
    protected UnityEvent Response;

    private void OnEnable() => Event.RegisterListener(this);

    private void OnDisable() => Event.UnregisterListener(this);

    public virtual void OnEventRaised() => Response?.Invoke();
}