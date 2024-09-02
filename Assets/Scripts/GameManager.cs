using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    public GameObject playerCamera;
    public GameObject player;

    //ui
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI treasureText;
    public TextMeshProUGUI artefactText;

    private void Awake()
    {
        gameManager = this;
    }
    public void StartGame()
    {
        player.SetActive(true);
        gameOverText.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        Debug.Log("Sorry player died.");
        gameOverText.gameObject.SetActive(true);
        
    }

    public void UpdateTreasure(int amount)
    {
        treasureText.text = "Treasure: "+amount.ToString();
    }

    public void ToggleArtefactUI(bool hasArtefact)
    {
        if (hasArtefact)
        {
            artefactText.text = "Has Artefact";
        }
        else
        {
            artefactText.text = "No artefact";
        }
    }
   
}
