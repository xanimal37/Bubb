using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : Spawnable, IMover, ITriggerable
{
   
    //variables
    private Vector3 moveVector=new Vector3(0,0,-1);
    private float _speed = 5.0f;
    public float speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    //test
    float lifetime = 0f;
    float maxLifetime = 6.0f;

    void OnEnable()
    {
        lifetime = 0;
    }

    private void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime > maxLifetime) { 
            Debug.Log("returned turtle");
            TurtlePool.Pool.ReturnToPool(this);
        }
        Move();
    }

    public void Move()
    {
        transform.Translate(moveVector*Time.deltaTime*_speed);
    }

    //when player triggers, player pass self reference
    public void ProcessTrigger(Player player)
    {
        Debug.Log("Hitched a ride on a turtle!");
        player.JumpOnTurtle(this);
        
      
    }
    
}
