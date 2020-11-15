using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Database_IDatabaseConnector;
using UnityEngine.Networking;
using System;

public class Database_PhpConnector : MonoBehaviour, Database_IDatabaseConnector
{
    public void TestDatabaseConnection()
    {
        Debug.Log("PHP Connection OK!");
    }

    public IEnumerator LoginUser(string login, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("login", login);
        form.AddField("password", password);
        string uri = "http://localhost/phpScripts/retrieveExistingPlayer.php";

        using (UnityWebRequest webRequest = UnityWebRequest.Post(uri, form))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                yield return webRequest.downloadHandler.text;
            }
        }
    }

    public IEnumerator UpdateScore(int playerId, int worldId, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("playerId", playerId);
        form.AddField("worldId", worldId);
        form.AddField("score", score);
        string uri = "http://localhost/phpScripts/updateScore.php";

        using (UnityWebRequest webRequest = UnityWebRequest.Post(uri, form))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                yield return webRequest.downloadHandler.text;
            }
        }
    }

    public IEnumerator RegisterUser(string login, string password, string repeatedPassword, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("login", login);
        form.AddField("password", password);
        form.AddField("repeatedPassword", repeatedPassword);
        form.AddField("email", email);
        string uri = "http://localhost/phpScripts/register.php";

        using (UnityWebRequest webRequest = UnityWebRequest.Post(uri, form))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                yield return webRequest.downloadHandler.text;
            }
        }
    }

    public IEnumerator ResetPassword(string login, string password, string repeatedPassword)
    {
        WWWForm form = new WWWForm();
        form.AddField("login", login);
        form.AddField("password", password);
        form.AddField("repeatedPassword", repeatedPassword);
        string uri = "http://localhost/phpScripts/resetPassword.php";

        using (UnityWebRequest webRequest = UnityWebRequest.Post(uri, form))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                yield return webRequest.downloadHandler.text;
            }
        }
    }
}
