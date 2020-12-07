using System.Collections;
using System.Collections.Generic;

public interface Database_IDatabaseConnector
{
	void TestDatabaseConnection();
	IEnumerator LoginUser(string login, string password);
	IEnumerator UpdateScore(int playerId, int worldId, int score);
	IEnumerator RegisterUser(string login, string password, string repeatedPassword, string email);
	IEnumerator ChangePassword(string login, string password, string repeatedPassword);
	IEnumerator RetrievePlayerScores(int playerId);
	IEnumerator RetrieveTopScores(int top, string login, int worldId);
}
