using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player player;
    private PlayerSize playerSize;

    private PlayerState state = PlayerState.NORMAL;

    private float movementCost = -0.25f;


    //physics and interactions
    Rigidbody rb;
    float power = 10.0f;
    //this will change based on bubble size
    private float physicsModifier = -0.1f;

    private void Awake()
    {
        //get references
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        //events
        player.playerStateChanged += HandlePlayerStateChanged;

    }
    private void Start()
    {
        playerSize = player.GetPlayerSize();
        //makes the bubble "float" up by making gravity negative
        Physics.gravity *= physicsModifier;  
        rb.drag = 0.5f;
    }

    private void HandlePlayerStateChanged(PlayerState newState)
    {
        state = newState;
    }

    private void Update()
    {
        if (state == PlayerState.NORMAL)
        {
            Move();
        }
    }

    public Rigidbody GetRigidBody()
    {
        return rb;
    }

    void Move()
    {

        //player movement basic input
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(-power, 0, 0, ForceMode.Impulse);
            playerSize.UpdateSize(movementCost);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(power, 0, 0, ForceMode.Impulse);
            playerSize.UpdateSize(movementCost);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(0, power, 0, ForceMode.Impulse);
            playerSize.UpdateSize(movementCost);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(0, -power, 0, ForceMode.Impulse);
            playerSize.UpdateSize(movementCost);
        }
    }

}
