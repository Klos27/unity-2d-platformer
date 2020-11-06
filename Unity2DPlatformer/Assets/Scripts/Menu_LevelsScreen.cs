using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu_LevelsScreen : MonoBehaviour
{
    public GameObject playerNameTextTMP;
    public GameObject scoreLevel1TextTMP;
    public GameObject scoreLevel2TextTMP;
    public GameObject scoreLevel3TextTMP;
    public GameObject scoreLevel4TextTMP;

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
        InitLevels();
    }

    public void InitLevels()
    {
        UpdatePlayerName();
        UpdateScores();
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
        SceneManager.LoadScene(level); // TODO: MAKE QUEUE FOR LEVELS?
    }

    void UpdateScores()
    {
        // Get scores from DB
        int playerId = PlayerPrefs.GetInt("playerId");

        List<int> playerScores = new List<int> { }; // TODO Get from DB
        playerScores.Add(111);
        playerScores.Add(222);
        playerScores.Add(333);
        playerScores.Add(444);

        // Update Scores
        //ArrayList scoreLevelTextTMP = new ArrayList();
        List<GameObject> scoreLevelTextTMP = new List<GameObject> { };
        scoreLevelTextTMP.Add(scoreLevel1TextTMP);
        scoreLevelTextTMP.Add(scoreLevel2TextTMP);
        scoreLevelTextTMP.Add(scoreLevel3TextTMP);
        scoreLevelTextTMP.Add(scoreLevel4TextTMP);

        int scoresSize = playerScores.Count < scoreLevelTextTMP.Count ? playerScores.Count : scoreLevelTextTMP.Count;

        for (int i = 0; i < scoresSize; ++i)
        {
            scoreLevelTextTMP[i].GetComponent<TMP_Text>().text = playerScores[i].ToString();
        }
    }
}
