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

    public bool LoginUser(string login, string password)
    {
        return true;
    }

    public void UpdateScore(int playerId, int worldId, int score)
    {
        // TODO Update player score if is higher than previous
        Debug.Log("Score updated: playerId=" + playerId + " worldId=" + worldId + " score=" + score);
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

            yield return webRequest.downloadHandler.text;
        }
    }
}
