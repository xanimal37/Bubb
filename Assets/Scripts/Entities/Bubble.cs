using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public abstract class Bubble : Spawnable, IMover, ICollidable
{
    public BubbleSize bubbleSize;
    public GameObject particleSystemGO;

    public event Action<BubbleSize> BubblePop;

    public float speed { get; set; }


    //set size on spawn
    private void OnEnable()
    {
        
        RegisterWithManagers();
    }

    public override void Die()
    {
        Instantiate(particleSystemGO,gameObject.transform.position,Quaternion.identity);
        BubblePop?.Invoke(bubbleSize);
        UnregisterWithManagers();
       base.Die();
    }

    public void SetSize(BubbleSize size)
    {
        bubbleSize = size;
        gameObject.transform.localScale = new Vector3((int)size, (int)size, (int)size);
    }

    public virtual void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
    }

    void Update()
    {
        Move();
    }

    public virtual void ProcessCollision(Player player)
    {
        
    }



}
