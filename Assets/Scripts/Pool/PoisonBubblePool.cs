using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoisonBubblePool : SpawnablePool
{
    public static PoisonBubblePool Pool { get; private set; }

    private void Awake()
    {
        Pool = this;
    }
}
