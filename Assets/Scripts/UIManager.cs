using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public GameObject activeUI;
    private GameState gameState;

    //gameUI
    private TextMeshProUGUI gameMessage;
    private TextMeshProUGUI depthText;

    //menuUI

    
    void Awake()
    {
        Instance = this;
        
    }

    private void Start()
    {
        GameManager.OnAfterGameStateChanged += HandleGameStateChanged;
    }

    public void HandleGameStateButtonPress(int gameStateIndex)
    {
        GameState gameState = (GameState)gameStateIndex;
        GameManager.Instance.ChangeState(gameState);
    }

    //allow the different UIs to register with the UIManager once they are loaded
   public void RegisterUI(GameObject uiObject, GameState gameState)
    {
        activeUI = uiObject;

        if (gameState == GameState.MENU) { }

        if(gameState == GameState.GAME) {
            gameMessage = activeUI.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            depthText = activeUI.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        }


    }

    //change UI based on game state
    void HandleGameStateChanged(GameState gameState)
    {

        if (gameState == GameState.GAMEOVER)
        {
            gameMessage.text = "GAME OVER";
        }
    }

    public void SetDepthText(string depth)
    {
        depthText.text = depth + " ft";
    }
}
