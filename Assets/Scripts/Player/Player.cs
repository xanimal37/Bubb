using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Bubble
{
    PlayerMove playerMove;
    //events
    public UnityEvent died;
    //state
    public PlayerState playerState { get; set; }

    void Start()
    {
        Spawn();
        playerMove = gameObject.GetComponent<PlayerMove>();
        playerState=PlayerState.NORMAL;
        size = 4;
    }

    //Collision detect
    private void OnCollisionEnter(Collision collision)
    {
        //get other entitity ICollidable
        ICollidable collidedWith = collision.gameObject.GetComponent<ICollidable>();
        if (collidedWith!=null && playerState!=PlayerState.ONTURTLE)
        {
            collidedWith.ProcessCollision(this);
        }

        CheckSize(); 
        
    }

    //Trigger detect
    private void OnTriggerEnter(Collider other)
    {
        //get other entity ITriggerable
        ITriggerable triggeredBy = other.gameObject.GetComponent<ITriggerable>();
        if (triggeredBy != null && playerState!=PlayerState.ONTURTLE) {
            triggeredBy.ProcessTrigger(this);
        }
    }

    public void CheckSize()
    {
        if (size <= 0)
        {
            died.Invoke();
        }

    }

    public void JumpOnTurtle(Turtle turtle)
    {
        playerMove.JumpOnTurtle(turtle);
        playerState = PlayerState.ONTURTLE;
    }

   
}