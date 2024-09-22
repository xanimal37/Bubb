using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Bubble
{
    //physics and interactions
    Rigidbody rb;
    float power = 10.0f;
    //this will change based on bubble size
    private float physicsModifier = -0.1f;

    //events
    public UnityEvent died;

    //state
    public PlayerState playerState { get; set; }


    void Start()
    {
        Spawn();
        playerState = PlayerState.NORMAL;
        size = 4;
        //makes the bubble "float" up by making gravity negative
        Physics.gravity *= physicsModifier;
        //get reference to rigidbody & Collider
        rb = GetComponent<Rigidbody>();
        if (rb != null) {
            Debug.Log("FOUND RB");
        }
        rb.drag = 0.5f;
    }

    private void Update()
    {
        if (playerState == PlayerState.NORMAL)
        {
            Move();
        }
    }

    public override void Move()
    {
        
            //player movement basic input
            if (Input.GetKeyDown(KeyCode.A))
            {
                rb.AddForce(-power, 0, 0, ForceMode.Impulse);
                size -= 0.25f;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                rb.AddForce(power, 0, 0, ForceMode.Impulse);
                size -= 0.25f;
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(0, power, 0, ForceMode.Impulse);
                size -= 0.25f;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.AddForce(0, -power, 0, ForceMode.Impulse);
                size -= 0.25f;
            }
            if (size <= 0) { died.Invoke(); }
        
    }

    //add a force to knock player back on collision with obstacle
    public void KnockBack(Transform obstacleTransform)
    {
        //get vector for knockback
        Vector3 playerDirectionVector = -(obstacleTransform.position - transform.position).normalized;
        Vector3 playerVelocity = rb.velocity;

        //knockback player
        rb.AddForce(playerDirectionVector.x * playerVelocity.x, playerDirectionVector.y * playerVelocity.y, playerDirectionVector.z * playerVelocity.z, ForceMode.Impulse);
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
        
        if (size <= 0) { died.Invoke(); }
        
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

    public void JumpOnTurtle(Turtle turtle)
    {
        playerState=PlayerState.ONTURTLE;
        rb.isKinematic = true;
        rb.detectCollisions = false;
        this.gameObject.transform.SetParent(turtle.gameObject.transform, false);
        
        
    }

    public void JumpOffTurtle(Turtle turtle)
    {
        playerState = PlayerState.NORMAL;
        rb.isKinematic = false;
        rb.detectCollisions = true;
        this.gameObject.transform.SetParent(null,false);
    }



}
    
    
