using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Database_IDatabaseConnector;
using UnityEngine.Networking;
using System;

public class Database_PhpConnector : MonoBehaviour, Database_IDatabaseConnector
{
    private readonly string baseUri = "http://localhost/phpScripts/";

    public void TestDatabaseConnection()
    {
        Debug.Log("PHP Connection OK!");
    }

    public IEnumerator LoginUser(string login, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("login", login);
        form.AddField("password", password);
        string uri = baseUri + "retrieveExistingPlayer.php";

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
        string uri = baseUri + "updateScore.php";

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
        string uri = baseUri + "register.php";

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

    public IEnumerator RetrievePlayerScores(int playerId)
    {
        WWWForm form = new WWWForm();
        form.AddField("playerId", playerId);
        string uri = baseUri + "retrievePlayerScores.php";

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

    public IEnumerator ChangePassword(string login, string password, string repeatedPassword)
    {
        WWWForm form = new WWWForm();
        form.AddField("login", login);
        form.AddField("password", password);
        form.AddField("repeatedPassword", repeatedPassword);
        string uri = "http://localhost/phpScripts/changePassword.php";

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
