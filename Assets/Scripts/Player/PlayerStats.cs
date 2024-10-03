using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    
    public int treasure { get; set; }
    public bool hasArtefact { get; set; }

    private void Awake()
    {
        treasure = 0;
        hasArtefact = false;
    }
}
