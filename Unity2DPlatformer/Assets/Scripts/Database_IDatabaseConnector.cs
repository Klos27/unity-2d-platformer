using System.Collections;
using System.Collections.Generic;

public interface Database_IDatabaseConnector
{
    void TestDatabaseConnection();
    bool LoginUser(string login, string password);
    void UpdateScore(int playerId, int worldId, int score);
}
