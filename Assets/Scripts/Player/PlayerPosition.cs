using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private GameObject bottom;

    private void Start()
    {
        bottom = GameObject.Find("bottom");
    }

    private void FixedUpdate()
    {
        GameManager.gameManager.UpdateDepth(GetDepth().ToString());
    }

    private int GetDepth()
    {
        //caulcuate distance from bottom
        float depth = Vector3.Distance(gameObject.transform.position, bottom.transform.position);
        return Mathf.RoundToInt(depth);
    }
}
