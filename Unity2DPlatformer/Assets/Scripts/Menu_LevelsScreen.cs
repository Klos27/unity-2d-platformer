using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using static Database_Utils;

public class Menu_LevelsScreen : MonoBehaviour
{
	private Database_Utils databaseUtils = null;

	public GameObject playerNameTextTMP;
	public GameObject scoreLevel1TextTMP;
	public GameObject scoreLevel2TextTMP;
	public GameObject scoreLevel3TextTMP;
	public GameObject scoreLevel4TextTMP;
	private Dictionary<int, GameObject> scores = null;

	private string playerName = "";

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnEnable()
	{
		if (databaseUtils == null)
		{
			databaseUtils = new Database_Utils();
		}
		InitLevels();
	}

	public void InitLevels()
	{
		UpdatePlayerName();
		InitScoresFields();
		ResetScoresFields();
		StartCoroutine(UpdateScores());		
	}

	void InitScoresFields()
	{
		if (scores == null)
		{
			scores = new Dictionary<int, GameObject>();
			scores.Add(1, scoreLevel1TextTMP);
			scores.Add(2, scoreLevel2TextTMP);
			scores.Add(3, scoreLevel3TextTMP);
			scores.Add(4, scoreLevel4TextTMP);
		}
	}

	void ResetScoresFields()
	{
		foreach (int key in scores.Keys)
		{
			scores[key].GetComponent<TMP_Text>().text = "0";
		}
	}

	void UpdatePlayerName()
	{
		// Update player name
		playerName = PlayerPrefs.GetString("playerName");
		playerNameTextTMP.GetComponent<TMP_Text>().text = "Player: " + playerName;
	}

	public void PlayLevel1()
	{
		Debug.Log("Play level 1");
		PlayGame("Level_1");
	}

	public void PlayLevel2()
	{
		Debug.Log("Play level 2");
		PlayGame("Level_2");
	}

	public void PlayLevel3()
	{
		Debug.Log("Play level 3");
		PlayGame("Level_3");
	}

	public void PlayLevel4()
	{
		Debug.Log("Play level 4");
		PlayGame("Level_4");
	}

	void PlayGame(string level)
	{
		SceneManager.LoadScene(level);
	}

	private IEnumerator UpdateScores()
	{
		string playerName = PlayerPrefs.GetString("playerName");
		if (!playerName.Equals("Guest"))
		{
			int playerId = PlayerPrefs.GetInt("playerId");

			CoroutineWithData cd = new CoroutineWithData(this, databaseUtils.RetrievePlayerScores(playerId));
			yield return cd.coroutine;
			string receivedMessage = (string)cd.result;

			if (receivedMessage[0] == '0')
			{
				string[] rows = receivedMessage.Split('\n');

				for (int i = 1; i < rows.Length; i++)
				{
					string row = rows[i];
					int worldId = int.Parse(row.Split('\t')[0]);
					string score = row.Split('\t')[1];
					scores[worldId].GetComponent<TMP_Text>().text = score;
				}
			}
		}
	}
}
