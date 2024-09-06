using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject alertMessageGO;
    public TextMeshProUGUI alertMessage;
    public TextMeshProUGUI treasureText;
    public TextMeshProUGUI artefactText;


    public static UIManager uiManager { get; private set; }

    private void Awake()
    {
        uiManager = this;
        alertMessageGO.SetActive(false);
    }

    public void ShowAlertMessage(string msgText)
    {
        alertMessageGO.SetActive(true);
        alertMessage.text = msgText;
    }

    public void UpdateTreasureText(string msgText) {
        treasureText.text = msgText;

    }

    public void UpdateArtefactText(string msgText) {
        artefactText.text = msgText;
    }  

}
