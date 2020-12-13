using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu_Ladderboards : MonoBehaviour
{
	private Database_Utils databaseUtils = null;

	public GameObject levelsTextTMP;
	public GameObject ranksTextTMP;
	public GameObject playerNamesTextTMP;
	public GameObject scoresTextTMP;

	private string m_playerName = "";
	private int m_playerId = 0;
	private int m_actualLevelId = 1;
	private string m_ranks = "";
	private string m_playerNames = "";
	private string m_scores = "";
	private const int m_numberOfLevels = 4;
	private const int m_top = 10;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void UpdatePlayerCredentials()
	{
		m_playerName = PlayerPrefs.GetString("playerName");
		m_playerId = PlayerPrefs.GetInt("playerId");
	}

	public void UpdateLadderboards()
	{
		// This function is called once when entering ladderboards
		Debug.Log("Get ladderboards");
		if (databaseUtils == null)
		{
			databaseUtils = new Database_Utils();
		}
		UpdatePlayerCredentials();
		StartCoroutine(RetrieveTopScores());
	}

	void RenderLadderboards()
	{
		levelsTextTMP.GetComponent<TMP_Text>().text = "LEVEL " + m_actualLevelId;
		ranksTextTMP.GetComponent<TMP_Text>().text = m_ranks;
		playerNamesTextTMP.GetComponent<TMP_Text>().text = m_playerNames;
		scoresTextTMP.GetComponent<TMP_Text>().text = m_scores;
	}

	void ClearLadderboards()
	{
		m_ranks = "";
		m_playerNames = "";
		m_scores = "";
		RenderLadderboards();
	}

	void AddSkippingRow()
	{
		m_ranks += "...\n";
		m_playerNames += "\n";
		m_scores += "\n";
	}

	void AddPlayerToLadderboards(string rank, string playerName, string score)
	{
		m_ranks += rank + "\n";
		m_playerNames += playerName + "\n";
		m_scores += score + "\n";
	}

	void RemoveLastNewLinesInLeaderboards()
	{
		m_ranks = m_ranks.TrimEnd('\n');
		m_playerNames = m_playerNames.TrimEnd('\n');
		m_scores = m_scores.TrimEnd('\n');
	}

	void incrementLevelId()
	{
		// Range 1 - m_numberOfLevels
		if (m_actualLevelId == m_numberOfLevels)
		{
			m_actualLevelId = 1;
		}
		else
		{
			++m_actualLevelId;
		}
	}

	void decrementLevelId()
	{
		// Range 1 - m_numberOfLevels
		if (m_actualLevelId == 1)
		{
			m_actualLevelId = m_numberOfLevels;
		}
		else
		{
			--m_actualLevelId;
		}
	}


	public void PreviousLevelButtonClicked()
	{
		Debug.Log("PreviousLevelButtonClicked()");
		decrementLevelId();
		StartCoroutine(RetrieveTopScores());
	}

	public void NextLevelButtonClicked()
	{
		Debug.Log("NextLevelButtonClicked()");
		incrementLevelId();
		StartCoroutine(RetrieveTopScores());
	}

	private IEnumerator RetrieveTopScores()
	{
		string currPlayerName = PlayerPrefs.GetString("playerName");

		if (!currPlayerName.Equals("Guest"))
		{
			CoroutineWithData cd = new CoroutineWithData(this, databaseUtils.RetrieveTopScores(m_top, currPlayerName, m_actualLevelId));
			yield return cd.coroutine;
			string receivedMessage = (string)cd.result;
			string[] rows = receivedMessage.Split('\n');

			ClearLadderboards();

			for (int i = 0; i < rows.Length; i++)
			{
				if (i == m_top)
				{
					AddSkippingRow();
				}

				string row = rows[i];
				string rank = row.Split('\t')[0];
				string playerName = row.Split('\t')[1];
				string score = row.Split('\t')[2];
				AddPlayerToLadderboards(rank, playerName, score);
			}

			RemoveLastNewLinesInLeaderboards();
			RenderLadderboards();
		}
	}
}
