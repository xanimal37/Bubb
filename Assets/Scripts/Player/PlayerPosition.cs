using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public GameObject oceanBottom;
    private string distanceFromBottom;

    private void FixedUpdate()
    {
        distanceFromBottom=GetDepth().ToString();
        UIManager.Instance.SetDepthText(distanceFromBottom);
    }

    private int GetDepth()
    {
        //caulcuate distance from bottom
        float depth = Vector3.Distance(gameObject.transform.position, oceanBottom.transform.position);
        return Mathf.RoundToInt(depth);
    }
}
