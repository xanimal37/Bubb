using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    public GameObject playerCamera;
    public GameObject playerGO;

    private PlayerStats playerStats;
    private PlayerPosition playerPosition;

    private void Awake()
    {
        gameManager = this;
        playerStats=GetComponent<PlayerStats>();
        
    }

    private void Start()
    {
        StartGame();
    }

    public void GameOver()
    {
        UIManager.uiManager.ShowAlertMessage("GAME OVER");
        playerGO.SetActive(false);
    }

    public void StartGame()
    {   
        UIManager.uiManager.ShowAlertMessage("A Baby Turtle got drawn too deep by the current! \nGet to it so it can have enough air to reach the surface!");
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

    public void UpdateDepth(string depth)
    {
        UIManager.uiManager.UpdateDepthText(depth.ToString());
    }
   
}
