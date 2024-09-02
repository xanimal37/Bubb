using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bubble : Spawnable, IMover
{
    private float _size;
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

    //set size on spawn
    private void OnEnable()
    {
        gameObject.transform.localScale = new Vector3(size,size,size);
    }

    public virtual void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
    }

    void Update()
    {
        Move();
    }
}
