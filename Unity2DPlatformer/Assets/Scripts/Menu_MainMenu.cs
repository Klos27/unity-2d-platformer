using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;

public class Menu_MainMenu : MonoBehaviour
{
    public GameObject playerNameTextTMP;

    private string playerName = "";

    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayerName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdatePlayerName()
    {
        // Update player name
        playerName = PlayerPrefs.GetString("playerName");
        playerNameTextTMP.GetComponent<TMP_Text>().text = "Player: " + playerName;
    }

    public void Logout()
    {
        PlayerPrefs.DeleteKey("playerId");
        PlayerPrefs.DeleteKey("playerName");
    }
}
