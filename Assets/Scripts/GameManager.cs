using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState gameState;

    Player player;

    public static event Action<GameState> OnBeforeGameStateChanged;
    public static event Action<GameState> OnAfterGameStateChanged;

    private void Start()
    {
        Instance = this;
        //start the game in the first state
        ChangeState(GameState.MENU);

    }

    public void ChangeState(GameState newState)
    {
        if (newState == gameState)
        { return; }

            OnBeforeGameStateChanged?.Invoke(newState);

            gameState = newState;

            switch (gameState)
            {
                case GameState.MENU:
                    ShowMenu();
                    break;
                case GameState.GAME:
                    StartGame();
                    break;
                case GameState.GAMEOVER:
                    GameOver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }

            OnAfterGameStateChanged?.Invoke(newState);
    }

    private void ShowMenu() {
        SceneManager.LoadScene("Bubb_menu",LoadSceneMode.Single);
        
    }

    private void StartGame() {
        SceneManager.LoadScene("Bubb_game",LoadSceneMode.Single);
    }

    //register player
    //react to player events
    public void RegisterPlayer(Player p)
    {
        player = p;
        player.PlayerDied += HandlePlayerDied;
    }
    private void HandlePlayerDied()
    {
        ChangeState(GameState.GAMEOVER);
        player.PlayerDied -= HandlePlayerDied;
        player = null;
    }

    private void GameOver()
    {
        Timer gameOverTimer = new Timer(6.0f);
        gameOverTimer.SetAction(SetGameStateMenu);
        StartCoroutine(gameOverTimer.RunTimer());
    }

    //needs to be a method for the set action on the generic timer
    private void SetGameStateMenu()
    {
        ChangeState(GameState.MENU);
    }




}
