using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Player : Bubble
{
    Rigidbody rb;
    float power = 10.0f;
    //this will change based on bubble size
    private float physicsModifier = -0.1f;

    bool _hasArtefact;
    public bool hasArtefact
    {
        get { return _hasArtefact; }
        set { _hasArtefact = value; }
    }
    int _treasure;
    public int treasure
    {
        get { return _treasure; }
        set { _treasure = value; }
    }

    //events
    public UnityEvent died;

    private void Awake()
    {
        Spawn();
        _treasure = 0;
        _hasArtefact = false;
    }

    void Start()
    {
        size = 4;
        //makes the bubble "float" up by making gravity negative
        Physics.gravity *= physicsModifier;
        //get reference to rigidbody
        rb = GetComponent<Rigidbody>();
        rb.drag = 0.5f;
    }

    private void Update()
    {
        Move();
    }

    public override void Die()
    {
        base.Die();
        died.Invoke();

    }
    public override void Move()
    {
        //player lateral movement
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

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.LookRotation(rb.velocity);
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
        if (collidedWith!=null)
        {
            collidedWith.ProcessCollision(this);
        }
        
        if (size <= 0) { Die(); }
        UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        ITriggerable triggeredBy = other.gameObject.GetComponent<ITriggerable>();
        if (triggeredBy != null) { 
            triggeredBy.ProcessTrigger(this);
        }
      
        UpdateUI();
                
    }

    void UpdateUI()
    {
        GameManager.gameManager.UpdateTreasure(treasure);
        GameManager.gameManager.ToggleArtefactUI(hasArtefact);
    }
}
    
    
