using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu_ChangePassword : MonoBehaviour
{
    public GameObject passwordInputField;
    public GameObject rePasswordInputField;
    public GameObject dialogTextField;
    public GameObject playerNameTextTMP;

    private string m_password = "";
    private string m_rePassword = "";
    private string m_dialogText = "";
    private string playerName = "";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        dialogTextField.SetActive(false);
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

        Debug.Log("password=" + m_password);
        Debug.Log("rePassword=" + m_rePassword);
    }

    void updateCredentialsInForm()
    {
        passwordInputField.GetComponent<InputField>().text = m_password;
        rePasswordInputField.GetComponent<InputField>().text = m_rePassword;
        dialogTextField.GetComponent<Text>().text = m_dialogText;
    }

    public void changePasswordButtonClicked()
    {
        dialogTextField.SetActive(false);
        bool formValidateOk = true;

        getCredentialsFromForm();

        if (m_password == "" || m_rePassword == "")
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
        else
        {
            // TODO Try changing password in DB

            /* bool databaseError = false;
             if (databaseError)
             {
                 errorString = "Something went wrong with database connection!";
                 formValidateOk = false;
             }*/

            m_dialogText = "Password has been changed!";
        }

        if (formValidateOk)
        {
            // Remove credentials from form
            m_password = "";
            m_rePassword = "";
        }

        // Show dialog box
        dialogTextField.SetActive(true);
        updateCredentialsInForm();
    }
}
