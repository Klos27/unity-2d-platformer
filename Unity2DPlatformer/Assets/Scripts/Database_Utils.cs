﻿using System.Collections;
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

	// Default connectionType set to Php
	public Database_Utils(DatabaseConnectionType connectionType = DatabaseConnectionType.Php)
	{
		if (connectionType == DatabaseConnectionType.MySql)
		{
			Debug.Log("Database_Utils Create MySqlConnection");
			m_databaseConnector = new Database_MySqlConnector { };
		}
		else // if (connectionType == DatabaseConnectionType.MySql)
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

	public IEnumerator LoginUser(string login, string password)
	{
		return m_databaseConnector.LoginUser(login, password);
	}

	public IEnumerator UpdateScore(int playerId, int worldId, int score)
	{
		return m_databaseConnector.UpdateScore(playerId, worldId, score);
	}
	public IEnumerator RegisterUser(string login, string password, string repeatedPassword, string email)
	{
		return m_databaseConnector.RegisterUser(login, password, repeatedPassword, email);
	}

	public IEnumerator ChangePassword(string login, string password, string repeatedPassword)
	{
		return m_databaseConnector.ChangePassword(login, password, repeatedPassword);
	}

	public IEnumerator RetrievePlayerScores(int playerId)
	{
		return m_databaseConnector.RetrievePlayerScores(playerId);
	}

	public IEnumerator RetrieveTopScores(int top, string login, int worldId)
	{
		return m_databaseConnector.RetrieveTopScores(top, login, worldId);
	}
}
