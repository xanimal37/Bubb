using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameUI;

    public TextMeshProUGUI alertMessage;
    public TextMeshProUGUI treasureText;
    public TextMeshProUGUI artefactText;
    public TextMeshProUGUI depthText;


    public static UIManager uiManager { get; private set; }

    public void UpdateGameState(GameState state)
    {
        if (state == GameState.GAME) { 
            mainMenu.SetActive(false);
            gameUI.SetActive(true);
        }
    }

    private void Start()
    {
        uiManager = this;
        gameUI.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ShowAlertMessage(string msgText)
    {
        alertMessage.text = msgText;
    }

    public void UpdateTreasureText(string msgText) {
        treasureText.text = msgText;

    }

    public void UpdateArtefactText(string msgText) {
        artefactText.text = msgText;
    }  

    public void UpdateDepthText(string depth)
    {
        depthText.text = depth;
    }

}
