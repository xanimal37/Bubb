using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBubblePool : SpawnablePool
{
    public static NormalBubblePool Pool { get; private set; }

    private void Awake()
    {
        Pool = this;
    }
}
