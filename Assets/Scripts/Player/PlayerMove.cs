using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Player player;

    Timer timer = null;

    //physics and interactions
    Rigidbody rb;
    float power = 10.0f;
    //this will change based on bubble size
    private float physicsModifier = -0.1f;

    private void Awake()
    {
        //get references
        player = GetComponent<Player>();
    }
    private void Start()
    {
        //makes the bubble "float" up by making gravity negative
        Physics.gravity *= physicsModifier;
        //get reference to rigidbody & Collider
        rb = GetComponent<Rigidbody>();
        rb.drag = 0.5f;
    }

    private void Update()
    {
        if (player.playerState != PlayerState.ONTURTLE)
        {
            Move();
        }
    }

    void Move()
    {

        //player movement basic input
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(-power, 0, 0, ForceMode.Impulse);
            player.size -= 0.25f;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(power, 0, 0, ForceMode.Impulse);
            player.size -= 0.25f;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(0, power, 0, ForceMode.Impulse);
            player.size -= 0.25f;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(0, -power, 0, ForceMode.Impulse);
            player.size -= 0.25f;
        }
        player.CheckSize();
    }


    public void JumpOnTurtle(Turtle turtle)
    {
        rb.isKinematic = true;
        rb.detectCollisions = false;
        this.gameObject.transform.SetParent(turtle.gameObject.transform, true);
        Debug.Log("JUMPED ON turTLE");
        timer = new Timer(6);
        timer.SetAction(JumpOffTurtle);
        IEnumerator coroutineTimer = timer.RunTimer();
        StartCoroutine(coroutineTimer);
    }

    public void JumpOffTurtle()
    {
        //get the turtle component of the turtle gameobject
        Turtle turtle = this.gameObject.transform.parent.gameObject.GetComponent<Turtle>();
        //"get off" the turtle
        this.gameObject.transform.SetParent(null, true);
        //remove turtle from game
        turtle.Die();
        Debug.Log("JUMPED OFF TURTLE");

        //Create a timer
        //after 2 seconds make the player invulnerable (this will become a variable time length)
        timer = new Timer(2);
        timer.SetAction(() => {
            rb.isKinematic = false;
            rb.detectCollisions = true;
            player.playerState = PlayerState.NORMAL;

        });
        IEnumerator coroutineTimer = timer.RunTimer();
        StartCoroutine(coroutineTimer);
    }

}
