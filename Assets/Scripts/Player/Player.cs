using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Bubble
{
    Rigidbody rb;
    float power = 10.0f;
    //this will change based on bubble size
    private float physicsModifier = -0.1f;

    bool _hasArtefact;

    public GameEventListener pickUp;

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
        if (collidedWith!=null)
        {
            collidedWith.ProcessCollision(this);
        }
        
        if (size <= 0) { Die(); }
        UpdateUI();
    }

    void UpdateUI()
    {
        GameManager.gameManager.UpdateTreasure(treasure);
        GameManager.gameManager.ToggleArtefactUI(hasArtefact);
    }

    public void PICKUPTEST()
    {
        UIManager.uiManager.ShowAlertMessage("Picked up an artefact!");
    }

    public void PICKUPTEST2()
    {
        UIManager.uiManager.ShowAlertMessage("Picked up an treasure!");
    }


}
    
    
