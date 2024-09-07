using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Collectible Event", menuName = "Collectible Event",order=0)]
public class CollectibleEvent : ScriptableObject
{
    private List<CollectibleEventListener> eListeners = new List<CollectibleEventListener>();

    public void Register(CollectibleEventListener eListener) {
        eListeners.Add(eListener);
    }

    public void Unregister(CollectibleEventListener eListener) {
        eListeners.Remove(eListener);
    }

    public void Occurred(Collectible collectible)
    {
        for (int i = 0; i < eListeners.Count; i++) {
            eListeners[i].OnEventOccurs(collectible);
        }     
    }
}
