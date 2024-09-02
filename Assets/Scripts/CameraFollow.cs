using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public bool isFollowing = true;

    // Update is called once per frame
    void LateUpdate()
    {
        if (isFollowing) { 
        transform.position = player.transform.position + new Vector3(0, 0, -24);
    }
    }
}
