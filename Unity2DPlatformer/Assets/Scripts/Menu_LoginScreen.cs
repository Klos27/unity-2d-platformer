using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Database_Utils;

public class Menu_LoginScreen : MonoBehaviour
{
    public GameObject loginInputField;
    public GameObject passwordInputField;
    public GameObject dialogText;
    public GameObject background_MainMenu;
    public GameObject background_LoginScreen;

    private string login = "";
    private string password = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void exitGame()
    {
        Debug.Log("Exit game");
        Application.Quit();
    }

    public void loginButtonClicked()
    {
        dialogText.SetActive(false);
        bool shouldBeLogged = false;
        
        // Get login password from form
        login = loginInputField.GetComponent<InputField>().text;
        password = passwordInputField.GetComponent<InputField>().text;

        Debug.Log("login=" + login);
        Debug.Log("password=" + password);

        int playerId;
        string playerName;

        if (login == "Guest")
        {
            shouldBeLogged = true;
            playerId = 0;
            playerName = "Guest";
        }
        else
        {
            // TODO Connect to DB and check if player could be logged in
            playerId = 999999;
            playerName = login;
            Debug.Log("DB playerId=" + playerId);
            Debug.Log("DB playerName=" + playerName);

            //Database_Utils databaseUtils = new Database_Utils { };    // Enable MySqlConnector by default
            Database_Utils databaseUtils = new Database_Utils (DatabaseConnectionType.Php); // Enable PhpConnector in constructor
            databaseUtils.TestDatabaseConnection();
        }

        if (shouldBeLogged)
        {
            // Save playerId and playerName in memory
            PlayerPrefs.SetInt("playerId", playerId);
            PlayerPrefs.SetString("playerName", playerName);
            PlayerPrefs.Save();

            // Change screen to mainMenu
            background_LoginScreen.SetActive(false);
            background_MainMenu.SetActive(true);
        }
        else
        {
            // Display login error
            dialogText.SetActive(true);
        }
    }
}
