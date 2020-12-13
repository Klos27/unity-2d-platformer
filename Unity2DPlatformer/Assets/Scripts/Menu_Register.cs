using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Utils.RegexValidator;

public class Menu_Register : MonoBehaviour
{
    private Database_Utils databaseUtils;

    public GameObject loginInputField;
    public GameObject emailInputField;
    public GameObject passwordInputField;
    public GameObject rePasswordInputField;
    public GameObject dialogText;

    private string m_login = "";
    private string m_email = "";
    private string m_password = "";
    private string m_rePassword = "";
    private string m_dialogText = "";

    // Start is called before the first frame update
    void Start()
    {
        dialogText.SetActive(false);
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
        Application.Quit();
    }

    void getCredentialsFromForm()
    {
        m_login = loginInputField.GetComponent<InputField>().text;
        m_email = emailInputField.GetComponent<InputField>().text;
        m_password = passwordInputField.GetComponent<InputField>().text;
        m_rePassword = rePasswordInputField.GetComponent<InputField>().text;
    }

    void updateCredentialsInForm()
    {
        loginInputField.GetComponent<InputField>().text = m_login;
        emailInputField.GetComponent<InputField>().text = m_email;
        passwordInputField.GetComponent<InputField>().text = m_password;
        rePasswordInputField.GetComponent<InputField>().text = m_rePassword;
    }

    private void clearCredentialsForm()
    {
        m_login = "";
        m_email = "";
        m_password = "";
        m_rePassword = "";
    }

    private void clearDialogText()
    {
        m_dialogText = "";
    }

    void updateDialogText()
    {
        dialogText.GetComponent<Text>().text = m_dialogText;
    }

    public void logInButtonClicked()
    {
        clearDialogText();
        updateDialogText();
    }

    public void createAccountButtonClicked()
    {
        dialogText.SetActive(false);
        getCredentialsFromForm();
        StartCoroutine(registerUser(m_login, m_password, m_rePassword, m_email));
    }

    private IEnumerator registerUser(string login, string password, string repeatedPassword, string email)
    {
        CoroutineWithData cd = new CoroutineWithData(this, databaseUtils.RegisterUser(login, password, repeatedPassword, email));
        yield return cd.coroutine;
        try
        {
            string registrationReceivedMessage = (string)cd.result;
            if ("0".Equals(registrationReceivedMessage))
            {
                m_dialogText = "Account has been created. You can log in";
                clearCredentialsForm();
                updateCredentialsInForm();
            }
            else
            {
                m_dialogText = registrationReceivedMessage;
            }
            updateDialogText();
            dialogText.SetActive(true);
        }
        catch (System.Exception)
        {
            m_dialogText = "Error while connecting to database";
            updateDialogText();
            dialogText.SetActive(true);
        }
    }
}
