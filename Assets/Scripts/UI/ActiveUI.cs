using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveUI : MonoBehaviour
{ 
    public GameState uiGameState;

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.RegisterUI(gameObject,uiGameState);
    }

    
}
