using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player player;
    private PlayerSize playerSize;
    

    //physics and interactions
    private float drag = 0.01f;
    Rigidbody rb;
    float power = 10.0f;
    //this will change based on bubble size
    private float physicsModifier = -0.2f;
    //gameplay flags
    private bool isInCurrent = false;
    

    private void Awake()
    {
        //get references
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
       

    }
    private void Start()
    {
        playerSize = player.GetPlayerSize();
        //makes the bubble "float" up by making gravity negative
        SetGravity(physicsModifier);
        SetDrag(drag);
       
    }

    public void ToggleIsInCurrent(bool inCurrent)
    {
        isInCurrent = inCurrent;
    }

    public void SetGravity(float g)
    {
        Physics.gravity *= g;
    }

    public void SetDrag(float d)
    {
        rb.drag = d;
    }



    public Rigidbody GetRigidBody()
    {
        return rb;
    }

    private void Update()
    {

        Move();

            if (isInCurrent) {
            rb.AddForce(new Vector3(0, 10, 0));
            }
    }

    void Move()
    {

        //player movement basic input
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(-power, 0, 0, ForceMode.Impulse);
           
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(power, 0, 0, ForceMode.Impulse);
            
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(0, power, 0, ForceMode.Impulse);
           
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(0, -power, 0, ForceMode.Impulse);
           
        }
    }

}
