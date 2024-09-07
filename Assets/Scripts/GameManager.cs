using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    public GameObject playerCamera;
    public GameObject player;

    private PlayerStats playerStats;

    private void Awake()
    {
        gameManager = this;
        playerStats=GetComponent<PlayerStats>();
    }
    public void StartGame()
    {
        
    }

    public void GameOver()
    {
        UIManager.uiManager.ShowAlertMessage("GAME OVER");
        player.SetActive(false);
    }

    public void UpdateTreasure()
    {
        playerStats.treasure++;
       UIManager.uiManager.UpdateTreasureText( "Treasure: "+playerStats.treasure.ToString());
    }

    public void PickUpArtefact()
    {
        playerStats.hasArtefact = true;
        UIManager.uiManager.UpdateArtefactText("Artefact: " + playerStats.hasArtefact.ToString());
    }

    public void CollectiblePickedUp(Collectible collectible)
    {
        if(collectible is Artefact)
        
            {PickUpArtefact(); 
        }
        if(collectible is Treasure)
        {
            UpdateTreasure();
        }
    }
   
}
