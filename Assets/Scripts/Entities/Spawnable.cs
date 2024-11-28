using UnityEngine;
using System.Collections;

public abstract class Spawnable : MonoBehaviour
{

    MeshRenderer meshRenderer;
    Collider coll;

    private void Awake()
    {
        gameObject.SetActive(false);
        meshRenderer = GetComponent<MeshRenderer>();
        coll = GetComponent<Collider>();
    }

    public virtual void Spawn() {
        gameObject.SetActive(true);
        if (meshRenderer != null) {
            meshRenderer.enabled = true;
        }
        if (coll != null)
        {
            coll.enabled = true; 
        }
    }

    public virtual void Die(){
       gameObject.SetActive(false);
    }

    IEnumerator DelayedDeath()
    {
        yield return new WaitForSecondsRealtime(1);
        gameObject.SetActive(false);
    }

    public virtual void RegisterWithManagers() { }

    public virtual void UnregisterWithManagers() { }

    
}
