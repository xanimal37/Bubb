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
        explodeParticles.Play();
    }

    public void PlayMoveParticles()
    {
        moveParticles.Play(); 
    }
}