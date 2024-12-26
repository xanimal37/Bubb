using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public static class GameController
{

    public static void ChangeState(GameState newState)
    {

        switch (newState)
        {
            case GameState.MENU:
                ShowMenu();
                break;
            case GameState.GAME:
                StartGame();
                break;
            case GameState.GAMEOVER:
                
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

    }

    private static void ShowMenu()
    {
        SceneManager.LoadScene("Bubb_menu", LoadSceneMode.Single);

    }

    private static void StartGame()
    {
        SceneManager.LoadScene("Bubb_game", LoadSceneMode.Single);
    }
}
