using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnablePool: MonoBehaviour
{
    [SerializeField]
    private Spawnable spawnable;
    [SerializeField]
    private int numSpawnables;
  
   // public static SpawnablePool Pool { get; private set; }
    private Queue<Spawnable> spawnables = new Queue<Spawnable>();

    private void Start()
    {
        for (int i = 0; i < numSpawnables; i++)
        {
            AddSpawnable();
        }
    }

    public Spawnable Get() {
        Spawnable s = null;
        if (spawnables.Count>0)
        {
            s = spawnables.Dequeue();
            s.Spawn();
            return s;
        }
        
        return null;
    }

    public void ReturnToPool(Spawnable s)
    {
        spawnables.Enqueue(s);
        
    }

    public void AddSpawnable() {
            Spawnable s = Instantiate(spawnable);
            spawnables.Enqueue(s);
    }

}
