using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    private Player player;
    private float size = 4.0f;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Start()
    {
        UpdateMesh();
    }

    private void UpdateMesh()
    {
        gameObject.transform.localScale = new Vector3 (size, size, size);
    }

    private void CheckSize()
    {
        if (size <= 0) {
            player.Die();
        }
    }

    public void UpdateSize(float deltaSize)
    {
        size += deltaSize;
        UpdateMesh();
        CheckSize();
    }
}
