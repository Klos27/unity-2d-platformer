using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu_ChangePassword : MonoBehaviour
{
    private Database_Utils databaseUtils = null;

    public GameObject passwordInputField;
    public GameObject rePasswordInputField;
    public GameObject dialogText;
    public GameObject playerNameTextTMP;

    private string m_password = "";
    private string m_rePassword = "";
    private string m_dialogText = "";
    private string playerName = "";

    // Start is called before the first frame update
    void Start()
    {
        if (databaseUtils == null)
        {
            databaseUtils = new Database_Utils();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        dialogText.SetActive(false);
        UpdatePlayerName();
    }

    void UpdatePlayerName()
    {
        // Update player name
        playerName = PlayerPrefs.GetString("playerName");
        playerNameTextTMP.GetComponent<TMP_Text>().text = "Player: " + playerName;
    }

    void getCredentialsFromForm()
    {
        m_password = passwordInputField.GetComponent<InputField>().text;
        m_rePassword = rePasswordInputField.GetComponent<InputField>().text;
    }

    void clearCredentialsForm()
    {
        m_password = "";
        m_rePassword = "";
    }

    void clearDialogText()
    {
        dialogText.GetComponent<Text>().text = "";
    }

    void updateCredentialsInForm()
    {
        passwordInputField.GetComponent<InputField>().text = m_password;
        rePasswordInputField.GetComponent<InputField>().text = m_rePassword;
    }

    void updateDialogText()
    {
        dialogText.GetComponent<Text>().text = m_dialogText;
    }

    public void backButtonClicked()
    {
        clearDialogText();
        updateDialogText();
    }

    public void changePasswordButtonClicked()
    {
        dialogText.SetActive(false);
        getCredentialsFromForm();
        StartCoroutine(resetPassword(PlayerPrefs.GetString("playerName"), m_password, m_rePassword));
    }

    private IEnumerator resetPassword(string login, string password, string repeatedPassword)
    {
        CoroutineWithData cd = new CoroutineWithData(this, databaseUtils.ChangePassword(login, password, repeatedPassword));
        yield return cd.coroutine;
        string receivedMessage = (string)cd.result;
        if ("0".Equals(receivedMessage))
        {
            m_dialogText = "Password has been changed";
            clearCredentialsForm();
            updateCredentialsInForm();
        }
        else
        {
            m_dialogText = receivedMessage;
        }
        updateDialogText();
        dialogText.SetActive(true);
    }
}
