using UnityEngine;
using UnityEngine.Events;

public abstract class Environment : MonoBehaviour
{
    public UnityEvent<string> environmentInteraction;
}
