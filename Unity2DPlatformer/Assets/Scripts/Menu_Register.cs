using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Utils.RegexValidator;

public class Menu_Register : MonoBehaviour
{
    public GameObject loginInputField;
    public GameObject emailInputField;
    public GameObject passwordInputField;
    public GameObject rePasswordInputField;
    public GameObject dialogTextField;

    private string m_login = "";
    private string m_email = "";
    private string m_password = "";
    private string m_rePassword = "";
    private string m_dialogText = "";

    // Start is called before the first frame update
    void Start()
    {
        dialogTextField.SetActive(false);
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

        Debug.Log("login=" + m_login);
        Debug.Log("email=" + m_email);
        Debug.Log("password=" + m_password);
        Debug.Log("rePassword=" + m_rePassword);
    }

    void updateCredentialsInForm()
    {
        loginInputField.GetComponent<InputField>().text = m_login;
        emailInputField.GetComponent<InputField>().text = m_email;
        passwordInputField.GetComponent<InputField>().text = m_password;
        rePasswordInputField.GetComponent<InputField>().text = m_rePassword;
        dialogTextField.GetComponent<Text>().text = m_dialogText;
    }

    bool validateEmail(string emailToValidate)
    {
        return (emailToValidate != "" && Utils.RegexValidator.isEmailValid(emailToValidate));
    }

    public void createAccountButtonClicked()
    {
        dialogTextField.SetActive(false);
        bool formValidateOk = true;

        getCredentialsFromForm();

        if (m_login == "")
        {
            m_dialogText = "Login cannot be empty!";
            formValidateOk = false;
        }
        else if (m_password == "" || m_rePassword == "")
        {
            m_dialogText = "Passwords cannot be empty!";
            formValidateOk = false;
        }
        else if (m_password.Length < 6)
        {
            m_dialogText = "Password has to have at least 6 characters!";
            formValidateOk = false;
        }
        else if (m_password != m_rePassword)
        {
            m_dialogText = "Passwords are not equal!";
            formValidateOk = false;
        }
        else if (!validateEmail(m_email))
        {
            m_dialogText = "Email is not correct!";
            formValidateOk = false;
        }
        else
        {
            // TODO Try creating account in DB

            /* bool databaseError = false;
             if (databaseError)
             {
                 errorString = "Something went wrong with database connection!";
                 formValidateOk = false;
             }*/

            m_dialogText = "Account has been created, now you can log in!";
        }

        if (formValidateOk)
        {
            // Remove credentials from form
            m_login = "";
            m_email = "";
            m_password = "";
            m_rePassword = "";
        }

        // Show dialog box
        dialogTextField.SetActive(true);
        updateCredentialsInForm();
    
    }
}
