using UnityEngine;

public abstract class Spawnable : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public virtual void Spawn() {
        gameObject.SetActive(true);
    }

    public virtual void Die(){
    gameObject.SetActive(false);
    }
}
