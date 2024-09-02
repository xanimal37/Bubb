using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPool : SpawnablePool
{
    public static FishPool Pool { get; private set; }

    private void Awake()
    {
        Pool = this;
    }
}
