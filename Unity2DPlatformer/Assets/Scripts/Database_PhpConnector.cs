using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Database_IDatabaseConnector;

public class Database_PhpConnector : Database_IDatabaseConnector
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
}
