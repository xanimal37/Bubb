using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtlePool : SpawnablePool
{

    public static TurtlePool Pool { get; private set; }

    private void Awake()
    {
        Pool = this;
    }
}
