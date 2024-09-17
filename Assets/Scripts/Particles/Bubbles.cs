using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour
{
    private ParticleSystem bubbleParticles;

    void Start()
    {
        bubbleParticles = GetComponent<ParticleSystem>();
    }

    public void PlayParticles()
    {
        bubbleParticles.Play();
    }

   
}
