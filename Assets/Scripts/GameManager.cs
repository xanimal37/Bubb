using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    Player player;

    private void Awake()
    {
        Instance = this;
    }

 
    //register player
    //react to player events
    public void RegisterPlayer(Player p)
    {
        player = p;
        player.PlayerDied += HandlePlayerDied;
        player.PlayerWon += HandlePlayerReachedGoal;
        
    }
    private void HandlePlayerDied()
    {
        player.PlayerDied -= HandlePlayerDied;
        player.PlayerWon -= HandlePlayerReachedGoal;
        player = null;
        GameOver("GAME OVER!");
        GameController.ChangeState(GameState.GAMEOVER); 
    }

    private void GameOver(string msg)
    {
        UIManager.Instance.UpdateGameMessage(msg);
        Timer gameOverTimer = new Timer(6.0f);
        gameOverTimer.SetAction(SetGameStateMenu);
        StartCoroutine(gameOverTimer.RunTimer());
    }

    //needs to be a method for the set action on the generic timer
    private void SetGameStateMenu()
    {
        GameController.ChangeState(GameState.MENU);
    }

    private void HandlePlayerReachedGoal(string msg)
    {
        
        player.PlayerDied -= HandlePlayerDied;
        player.PlayerWon -= HandlePlayerReachedGoal;
        player = null;
        GameOver(msg);
        GameController.ChangeState(GameState.GAMEOVER);

    }


}
