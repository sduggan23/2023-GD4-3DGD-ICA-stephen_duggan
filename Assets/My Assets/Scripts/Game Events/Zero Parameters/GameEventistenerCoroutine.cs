using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GameEventistenerCoroutine : GameEventListener
{
    [SerializeField] private float delay = 5f;

    //[SerializeField]
    //[Tooltip("Specify the game event (scriptable object) which will raise the event")]
    //private GameEvent Event;

    [SerializeField]
    private UnityEvent DelayedResponse;

    public override void OnEventRaised()
    {
        //Response.Invoke();
        StartCoroutine(RunDelayedEvent());
    }

    private IEnumerator RunDelayedEvent()
    {
        yield return new WaitForSeconds(delay);
        DelayedResponse.Invoke();
    }
}
