﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;

public class Database_MySqlConnector : Database_IDatabaseConnector
{
    MySqlConnection connection;
    string m_dbConnectionString = "server=localhost;" + "uid=root;" + "pwd=;" + "database=knights_vow;";

    public void TestDatabaseConnection()
    {
        TestDB();
    }

    private void SetupSQLConnection()
    {
        if (connection == null)
        {
            try
            {
                connection = new MySqlConnection(m_dbConnectionString);
                connection.Open();
            }
            catch (MySqlException ex)
            {
                Debug.LogError("MySQL Error: " + ex.ToString());
            }
        }
    }

    private void CloseSQLConnection()
    {
        if (connection != null)
        {
            connection.Close();
        }
    }

    private void TestDB()
    {
        string commandText = string.Format("INSERT INTO game_user (login, password, email) VALUES ({0}, {1}, {2})", "'NewPlayer'", "'qwerty'", "'email@email.com'");
        //string commandText = string.Format("INSERT INTO user_points (user_id, world_id, points) VALUES ({0}, {1}, {2})", 1, 2, 777);

        SetupSQLConnection();
        if (connection != null)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            try
            {
                command.ExecuteNonQuery();
                Debug.Log("Created player successfully");
            }
            catch (System.Exception ex)
            {
                Debug.LogError("MySQL error: " + ex.ToString());
            }
            finally
            {
                CloseSQLConnection();
            }
        }
    }

    public bool LoginUser(string login, string password)
    {
        return true;
    }
}