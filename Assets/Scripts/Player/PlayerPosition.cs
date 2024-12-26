using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public GameObject oceanBottom;
    private int distanceFromBottom;

    private void Start()
    {
        distanceFromBottom = GetDepth();
        UIManager.Instance.UpdateDepthText(distanceFromBottom);
    }

    private void FixedUpdate()
    {
        distanceFromBottom= GetDepth();
        UIManager.Instance.UpdateDepthText(distanceFromBottom);
    }

    private int GetDepth()
    {
        //caulcuate distance from bottom
        float depth = Vector3.Distance(gameObject.transform.position, oceanBottom.transform.position);
        return Mathf.RoundToInt(depth);
    }
}
