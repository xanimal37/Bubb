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

    //events
    public event Action<PlayerState> playerStateChanged;
    public event Action PlayerDied;

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
    }
    void Start()
    {
        RegisterWithManagers();
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
            triggeredBy.ProcessTrigger(this);
        }
    }

    public void Die()
    {
        playerRenderer.enabled = false;
        playerCollider.enabled = false;
        playerState = PlayerState.DEAD;
        PlayerDied?.Invoke();
        UnregisterWithManagers();
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

    public void SetPlayerParent(Transform trans)
    {
        transform.SetParent(trans,false);
    }

    private void RegisterWithManagers() { 
        AudioManager.Instance.RegisterPlayer(this);
        GameManager.Instance.RegisterPlayer(this);
    }

    private void UnregisterWithManagers() {
        AudioManager.Instance.UnregisterPlayer(this);
        
        }

}