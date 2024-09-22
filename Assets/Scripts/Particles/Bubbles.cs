using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem explodeParticles;
    [SerializeField]
    private ParticleSystem moveParticles;


    public void PlayExplodeParticles()
    {
        Debug.Log("PLAYING EXPLODE PARTICLES on " + gameObject.transform.parent.gameObject.name);
        explodeParticles.Play();
    }

    public void PlayMoveParticles()
    {
        Debug.Log("PLAYING MOVE PARTICLES!");
        moveParticles.Play(); 
    }
}