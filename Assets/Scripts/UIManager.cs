using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI gameMessage;
    public TextMeshProUGUI depthText;

    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameMessage.gameObject.SetActive(false);
    }

    public void UpdateGameMessage(string msg)
    {
        if (gameMessage != null) {
            gameMessage.text = msg;
        }
        gameMessage.gameObject.SetActive(true);
    }

    public void UpdateDepthText(int depth) {
        depthText.text = depth + " ft";
    }

   
}
