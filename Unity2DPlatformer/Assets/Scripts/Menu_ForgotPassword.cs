using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Utils.RegexValidator;

public class Menu_ForgotPassword : MonoBehaviour
{
    public GameObject emailInputField;
    public GameObject dialogTextField;

    private string m_email = "";
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

    void getCredentialsFromForm()
    {
        m_email = emailInputField.GetComponent<InputField>().text;
        Debug.Log("email=" + m_email);
    }

    void updateCredentialsInForm()
    {
        emailInputField.GetComponent<InputField>().text = m_email;
        dialogTextField.GetComponent<Text>().text = m_dialogText;
    }

    bool validateEmail(string emailToValidate)
    {
        return (emailToValidate != "" && Utils.RegexValidator.isEmailValid(emailToValidate));
    }

    public void resetPasswordButtonClicked()
    {
        dialogTextField.SetActive(false);
        bool formValidateOk = true;

        getCredentialsFromForm();

        if (!validateEmail(m_email))
        {
            // Move validation to PHP Script as is for Register
            //m_dialogText = "Email is not correct!";
            formValidateOk = false;
        }
        else
        {
            // TODO random generate password and put into DB

            /* bool databaseError = false;
             if (databaseError)
             {
                 errorString = "Something went wrong with database connection!";
                 formValidateOk = false;
             }*/

            m_dialogText = "Password has been reseted, check you e-mail!";
        }

        if (formValidateOk)
        {
            // Remove credentials from form
            m_email = "";
        }

        // Show dialog box
        dialogTextField.SetActive(true);
        updateCredentialsInForm();

    }
}
