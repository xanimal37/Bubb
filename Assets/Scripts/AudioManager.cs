using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{ 
    public static AudioManager Instance { get; private set; }

    AudioSource audioSource;

    //music
    public AudioClip music;
    public AudioClip ambient;

    //game
    public AudioClip bubblePop;

    private void Start()
    {
        Instance = this;

        audioSource = GetComponent<AudioSource>();
    }

    public void RegisterBubble(Bubble b) => b.BubblePop += HandlePop;

    public void UnregisterBubble(Bubble b) => b.BubblePop -= HandlePop;

    public void RegisterPlayer(Player p) => p.PlayerDied += HandlePop;

    public void UnregisterPlayer(Player p) =>p.PlayerDied -= HandlePop;


    public void HandlePop()
    {
        Debug.Log("Playing popped sound on popped event!");
        audioSource.clip = bubblePop;
        audioSource.Play();
    }


}
