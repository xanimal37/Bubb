using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public abstract class Bubble : Spawnable, IMover, ICollidable
{
    private float _size;
    public GameObject particleSystemGO;

    public event Action BubblePop;

    public float size
    {
        get { return _size; }
        set {
            _size = value;
            if (_size > 0)
            {
                gameObject.transform.localScale = new Vector3(size, size, size);
            }
            else
            {
                Die();
            }
        }
    }
    public float speed { get; set; }


    //set size on spawn
    private void OnEnable()
    {
        gameObject.transform.localScale = new Vector3(size,size,size);
        RegisterWithManagers();
    }

    public override void Die()
    {
        Instantiate(particleSystemGO,gameObject.transform.position,Quaternion.identity);
        BubblePop?.Invoke();
        UnregisterWithManagers();
       base.Die();
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

    public override void RegisterWithManagers()
    {
        AudioManager.Instance.RegisterBubble(this);
    }

    public override void UnregisterWithManagers()
    {
        AudioManager.Instance.UnregisterBubble(this);
    }


}
