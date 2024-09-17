using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public abstract class Bubble : Spawnable, IMover
{
    private float _size;
    private Bubbles bubbles;
    private MeshRenderer meshRenderer;
    private Collider thisCollider;
    public float size
    {
        get { return _size; }
        set {
            _size = value;
            if (_size > 0)
            {
                gameObject.transform.localScale = new Vector3(size, size, size);
            }
            else
            {
                Die();
            }
        }
    }
    public float speed { get; set; }

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        thisCollider = GetComponent<Collider>();
        if (meshRenderer == null) {
            meshRenderer = GetComponentInChildren<MeshRenderer>();
        }

    }

    //set size on spawn
    private void OnEnable()
    {
        if (meshRenderer != null) {
            meshRenderer.enabled = true;
        }
        if (thisCollider != null)
        {
            thisCollider.enabled = true;
        }
        gameObject.transform.localScale = new Vector3(size,size,size);
        bubbles = GetComponentInChildren<Bubbles>();
       
    }

    public override void Die()
    {
        if (meshRenderer != null)
        {
            meshRenderer.enabled =false;
        }
        if(thisCollider != null)
        {
            thisCollider.enabled = false;
        }
       
        bubbles.PlayParticles();
        StartCoroutine(DelayedDeath());
        
    }

    public virtual void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
    }

    void Update()
    {
        Move();
    }

    IEnumerator DelayedDeath()
    {
        yield return new WaitForSecondsRealtime(1);
        base.Die();
    }
}
