using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom : Environment,ICollidable
{

    PlayerPosition playerPosition;

    void Awake()
    {
        playerPosition =GameObject.Find("Player").GetComponent<PlayerPosition>();
        playerPosition.SetBottomLoc(gameObject.transform);
    }

    void ProcessCollision(Player player)
    {
        Debug.Log("HIT BOTTOM");
    }
}
