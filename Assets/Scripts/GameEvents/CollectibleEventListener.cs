using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class UnityCollectibleEvent : UnityEvent<Collectible>
{

}

public class CollectibleEventListener : MonoBehaviour
{
    public CollectibleEvent collEvent;
    public UnityCollectibleEvent response = new UnityCollectibleEvent();

    private void OnEnable()
    {
       collEvent.Register(this);

    }

    private void OnDisable()
    {
        collEvent.Unregister(this);
    }

    public void OnEventOccurs(Collectible collectible) 
    { 
        response.Invoke(collectible); 
    }
}
