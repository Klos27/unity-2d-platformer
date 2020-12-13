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
    public GameObject dialogText;
    public GameObject background_MainMenu;
    public GameObject background_LevelsScreen;
    public GameObject background_LoginScreen;

    private string m_login = "";
    private string m_password = "";
    private string m_dialogText = "";

    // Start is called before the first frame update
    void Start()
    {
        dialogText.SetActive(false);
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
        loginInputField.GetComponent<InputField>().text = m_login;
        passwordInputField.GetComponent<InputField>().text = m_password;
    }

    private void clearCredentialsForm()
    {
        m_login = "";
        m_password = "";
    }

    void updateDialogText()
    {
        dialogText.GetComponent<Text>().text = m_dialogText;
    }

    public void loginButtonClicked()
    {
        dialogText.SetActive(false);

        m_login = loginInputField.GetComponent<InputField>().text;
        m_password = passwordInputField.GetComponent<InputField>().text;

       StartCoroutine(logInUser(m_login, m_password));
    }

    private IEnumerator logInUser(string login, string password)
    {
        if (login.Equals("Guest"))
        {
            PlayerPrefs.SetInt("playerId", int.MaxValue);
            PlayerPrefs.SetString("playerName", m_login);
            PlayerPrefs.Save();

            clearCredentialsForm();
            updateCredentialsInForm();

            background_LoginScreen.SetActive(false);
            background_MainMenu.SetActive(true);
        }
        else
        {
            CoroutineWithData cd = new CoroutineWithData(this, databaseUtils.LoginUser(login, password));
            yield return cd.coroutine;
            try
            {
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
                    m_dialogText = receivedMessage;
                    updateDialogText();
                    dialogText.SetActive(true);
                }
            }
            catch (System.Exception)
            {
                m_dialogText = "Error while connecting to database";
                updateDialogText();
                dialogText.SetActive(true);
            }
        }
    }
}
