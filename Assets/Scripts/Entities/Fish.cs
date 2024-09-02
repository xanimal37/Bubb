using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Fish : Spawnable, IMover, IDamageable,ICollidable
{
    private float _speed;
    public float speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    private int _hitpoints;
    public int hitpoints
    {
        get { return _hitpoints; }
        set { _hitpoints = value; }
    }

    void OnEnable()
    {
        _speed = 5.0f;
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("FISH TAKING DAMANGE! " + damage);
    }

    public void ProcessCollision(Player player) {
        player.Die();
    }

    public void Move()
    {
        transform.Translate(_speed * Time.deltaTime*Vector3.right,Space.World);
    }

    void Update()
    {
        Move();
    }

}
