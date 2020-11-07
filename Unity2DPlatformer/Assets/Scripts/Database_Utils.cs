using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Database_MySqlConnector;
using static Database_PhpConnector;
using static Database_IDatabaseConnector;

public enum DatabaseConnectionType
{
    MySql,
    Php
}

public class Database_Utils
{
    Database_IDatabaseConnector m_databaseConnector;

    // Default connectionType set to MySql
    public Database_Utils(DatabaseConnectionType connectionType = DatabaseConnectionType.Php)
    {
        if (connectionType == DatabaseConnectionType.MySql)
        {
            Debug.Log("Database_Utils Create MySqlConnection");
            m_databaseConnector = new Database_MySqlConnector { };
        }
        else // if (connectionType == DatabaseConnectionType.Php)
        {
            Debug.Log("Database_Utils Create PhpConnection");
            GameObject gameObject = new GameObject();
            gameObject.AddComponent<Database_PhpConnector>();
            m_databaseConnector = gameObject.GetComponent<Database_PhpConnector>(); ;
        }
    }

    public void TestDatabaseConnection()
    {
        m_databaseConnector.TestDatabaseConnection();
    }

    public bool LoginUser(string login, string password)
    {
        return m_databaseConnector.LoginUser(login, password);
    }

    public void UpdateScore(int playerId, int worldId, int score)
    {
        m_databaseConnector.UpdateScore(playerId, worldId, score);
    }
    public IEnumerator RegisterUser(string login, string password, string repeatedPassword, string email)
    {
        return m_databaseConnector.RegisterUser(login, password, repeatedPassword, email);
    }
}
