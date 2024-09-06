using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEvent response;

    private void OnEnable()
    {
        gameEvent.Register(this);

    }

    private void OnDisable()
    {
        gameEvent.Unregister(this);
    }

    public void OnEventOccurs() { response.Invoke(); }
}
