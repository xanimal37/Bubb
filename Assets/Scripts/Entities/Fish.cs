using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Fish : Spawnable, IMover,ICollidable
{
    private float _speed;
    public float speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    void OnEnable()
    {
        _speed = 5.0f;
    }

    public void ProcessCollision(Player player) {
        player.Die();
        UIManager.uiManager.ShowAlertMessage("killed by a fish!");
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
