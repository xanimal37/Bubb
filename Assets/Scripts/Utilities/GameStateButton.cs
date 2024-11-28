using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateButton : MonoBehaviour
{
   public void ClickStartButton()
    {
        UIManager.Instance.HandleGameStateButtonPress(1);
    }

    

}
