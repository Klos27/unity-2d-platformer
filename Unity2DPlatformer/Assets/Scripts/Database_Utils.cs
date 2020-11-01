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
    public Database_Utils(DatabaseConnectionType connectionType = DatabaseConnectionType.MySql)
    {
        if (connectionType == DatabaseConnectionType.MySql)
        {
            Debug.Log("Database_Utils Create MySqlConnection");
            m_databaseConnector = new Database_MySqlConnector { };
        }
        else // if (connectionType == DatabaseConnectionType.Php)
        {
            Debug.Log("Database_Utils Create PhpConnection");
            m_databaseConnector = new Database_PhpConnector { };
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
}
