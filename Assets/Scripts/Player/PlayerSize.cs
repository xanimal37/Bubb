using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    private Player player;
    public BubbleSize bubbleSize { get; private set; }

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Start()
    {
        bubbleSize = BubbleSize.MEDIUM;
        UpdateMesh();
    }

    private void UpdateMesh()
    {
        int size = (int)bubbleSize;
        gameObject.transform.localScale = new Vector3 (size, size, size);
    }

    private void CheckSize()
    {
        if (bubbleSize==BubbleSize.DEAD) {
            player.Die();
        }
    }

    public void UpdateSize(BubbleSize otherBubbleSize, bool isDamage)
    {
        int otherBubbleSizeInt = (int)otherBubbleSize;
        Debug.Log(otherBubbleSizeInt);
        int size = (int)bubbleSize;
        Debug.Log(size);

        int newSize=0;

        if (isDamage)
        {
            newSize = size - otherBubbleSizeInt;
        }
        else
        {
            newSize = size + otherBubbleSizeInt;
        }

        Debug.Log("NEW SIZE IS: "+newSize);
        

        if (newSize <= 0)
        {
            bubbleSize = BubbleSize.DEAD;
        }
        else if (newSize > 4)
        {
            bubbleSize = BubbleSize.HUGE;
        }
        else
        {
            bubbleSize=(BubbleSize)newSize;
        }

        Debug.Log("****" + bubbleSize.ToString());

        UpdateMesh();
        CheckSize();
    }

    
}
