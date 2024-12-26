using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "ScriptableObjects/Audio Data", order = 1)]
public class AudioData : ScriptableObject
{

    [SerializeField]
    private List<AudioClip> clipList;

    public AudioClip GetClip(int index)
    {
        return clipList[index];
    }

}
