using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    public static MenuAudio Instance { get; private set; }

    public AudioData audioData;

    public AudioSource musicAudioSource;
    public AudioSource buttonClickAudioSource;

    private void Awake()
    {
        if(Instance == null) {
            Instance = this;
        }
        if (Instance != null) {
            Destroy(gameObject);
        }
       
    }

    public void PlayMenuMusic()
    {

    }

}
