using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    public GameObject player;

    private PlayerStats playerStats;
    private PlayerPosition playerPosition;
    public GameState gameState { get; private set; }

    public UnityEvent<GameState> gameStateChanged;
    

    private void Start()
    {
        gameManager = this;
        playerStats=GetComponent<PlayerStats>();
        player.SetActive(false);
        
    }


    public void GameOver()
    {
        UIManager.uiManager.ShowAlertMessage("GAME OVER");
        player.SetActive(false);
    }

    public void StartGame()
    {   
        UIManager.uiManager.ShowAlertMessage("A Baby Turtle got drawn too deep by the current! \nGet to it so it can have enough air to reach the surface!");
        gameState = GameState.GAME;
        gameStateChanged.Invoke(gameState);
        //load game scene 1
        SceneManager.LoadSceneAsync(1);
        player.SetActive(true);
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

    public void TEST_EVENT(string msg) {
        Debug.Log(msg);
    }

   
}
