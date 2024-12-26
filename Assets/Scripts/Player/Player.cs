using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player: MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerSize playerSize;
    private Bubbles bubbles;
    private MeshRenderer playerRenderer;
    private Collider playerCollider;

    private GameObject goal;

    //events
    public event Action PlayerDied;
    public event Action<string> PlayerWon;

    //state
    public PlayerState playerState = PlayerState.NORMAL;

    private void Awake()
    {
        //references
        playerInput = gameObject.GetComponent<PlayerInput>();
        playerSize = gameObject.GetComponent<PlayerSize>();
        bubbles = gameObject.GetComponentInChildren<Bubbles>();
        playerRenderer = GetComponentInChildren<MeshRenderer>();
        playerCollider = GetComponentInChildren<Collider>();

        goal = GameObject.FindGameObjectWithTag("Goal");
    }

    private void Start()
    {
        GameManager.Instance.RegisterPlayer(this);
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

    }

    //Trigger detect
    private void OnTriggerEnter(Collider other)
    {
        //get other entity ITriggerable
        ITriggerable triggeredBy = other.gameObject.GetComponent<ITriggerable>();
        if (triggeredBy != null) {
            triggeredBy.ProcessTriggerEntered(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ITriggerable triggeredBy = other.gameObject.GetComponent<ITriggerable>();
        if (triggeredBy != null) { 
            triggeredBy.ProcessTriggerExited(this); 
        }
    }

    public void Die()
    {
        playerRenderer.enabled = false;
        playerCollider.enabled = false;
        playerState = PlayerState.DEAD;
        PlayerDied?.Invoke();
        Invoke("DeactivatePlayer", 1.0f);
    }

    public void Win(string msg)
    {
        playerState = PlayerState.DEAD;
        playerRenderer.enabled = false;
        playerCollider.enabled = false;
        PlayerWon?.Invoke(msg);
        Invoke("DeactivatePlayer", 1.0f);
    }

    private void DeactivatePlayer()
    {
        gameObject.SetActive(false);
    }

    public PlayerSize GetPlayerSize()
    {
        return playerSize;
    }

    public PlayerInput GetPlayerInput() { return playerInput; }

    public Collider GetPlayerCollider() { return playerCollider; }

   private void ToggleCollider(bool isEnabled)
    {
        playerCollider.enabled = isEnabled;
    }

    private void ToggleKinematic(bool isKinematic) { 
        playerInput.GetRigidBody().isKinematic = isKinematic;
    }

   

}