using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Game Event", menuName = "Game Event",order=0)]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> eListeners = new List<GameEventListener>();

    public void Register(GameEventListener eListener) {
        eListeners.Add(eListener);
    }

    public void Unregister(GameEventListener eListener) {
        eListeners.Remove(eListener);
    }

    public void Occurred()
    {
        for (int i = 0; i < eListeners.Count; i++) {
            eListeners[i].OnEventOccurs();
        }     
    }
}
