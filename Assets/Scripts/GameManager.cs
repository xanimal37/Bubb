using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    public GameObject playerCamera;
    public GameObject player;

    private void Awake()
    {
        gameManager = this;
    }
    public void StartGame()
    {
        player.SetActive(true);
    }

    public void GameOver()
    {
        UIManager.uiManager.ShowAlertMessage("GAME OVER");
    }

    public void UpdateTreasure(int amount)
    {
       UIManager.uiManager.UpdateTreasureText( "Treasure: "+amount.ToString());
    }

    public void ToggleArtefactUI(bool hasArtefact)
    {
        if (hasArtefact)
        {
            UIManager.uiManager.UpdateArtefactText("Has Artefact");
        }
        else
        {
            UIManager.uiManager.UpdateArtefactText("No Artefact");
        }
    }
   
}
