using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private Transform bottomTransform=null;

    public void SetBottomLoc(Transform t)
    {
        bottomTransform = t;
    }

    private void FixedUpdate()
    {
        if (bottomTransform != null) { 
        GameManager.gameManager.UpdateDepth(GetDepth().ToString());
    }
    }

    private int GetDepth()
    {
        //caulcuate distance from bottom
        float depth = Vector3.Distance(gameObject.transform.position, bottomTransform.position);
        return Mathf.RoundToInt(depth);
    }
}
