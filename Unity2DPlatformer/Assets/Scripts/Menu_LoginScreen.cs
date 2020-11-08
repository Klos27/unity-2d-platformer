using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Database_Utils;

public class Menu_LoginScreen : MonoBehaviour
{
    private Database_Utils databaseUtils = null;

    public GameObject loginInputField;
    public GameObject passwordInputField;
    public GameObject dialogTextField;
    public GameObject background_MainMenu;
    public GameObject background_LevelsScreen;
    public GameObject background_LoginScreen;

    private string login = "";
    private string password = "";
    private string dialogText = "";

    // Start is called before the first frame update
    void Start()
    {
        dialogTextField.SetActive(false);
        if (PlayerPrefs.GetInt("playerId") != 0 &&
            PlayerPrefs.GetString("playerName") != "")
        {
            // Jump to LevelsScreen - Exit from level
            background_LoginScreen.SetActive(false);
            background_LevelsScreen.SetActive(true);
        }
        if (databaseUtils == null)
        {
            databaseUtils = new Database_Utils();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void exitGame()
    {
        Debug.Log("Exit game");
        PlayerPrefs.DeleteKey("playerId");
        PlayerPrefs.DeleteKey("playerName");
        Application.Quit();
    }

    void updateCredentialsInForm()
    {
        loginInputField.GetComponent<InputField>().text = login;
        passwordInputField.GetComponent<InputField>().text = password;
    }

    private void clearCredentialsForm()
    {
        login = "";
        password = "";
    }

    void updateDialogText()
    {
        dialogTextField.GetComponent<Text>().text = dialogText;
    }

    public void loginButtonClicked()
    {
        dialogTextField.SetActive(false);

        login = loginInputField.GetComponent<InputField>().text;
        password = passwordInputField.GetComponent<InputField>().text;

        StartCoroutine(logInUser(login, password));
    }

    private IEnumerator logInUser(string login, string password)
    {
        CoroutineWithData cd = new CoroutineWithData(this, databaseUtils.LoginUser(login, password));
        yield return cd.coroutine;
        string receivedMessage = (string)cd.result;
        if (receivedMessage[0] == '0')
        {
            int userId = int.Parse(receivedMessage.Split('\t')[1]);
            string userDbLogin = receivedMessage.Split('\t')[2];

            PlayerPrefs.SetInt("playerId", userId);
            PlayerPrefs.SetString("playerName", userDbLogin);
            PlayerPrefs.Save();

            clearCredentialsForm();
            updateCredentialsInForm();

            background_LoginScreen.SetActive(false);
            background_MainMenu.SetActive(true);
        }
        else
        {
            dialogText = receivedMessage;
            updateDialogText();
            dialogTextField.SetActive(true);
        }
    }
}
