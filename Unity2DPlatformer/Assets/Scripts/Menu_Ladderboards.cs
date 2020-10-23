using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu_Ladderboards : MonoBehaviour
{
    public GameObject levelsTextTMP;
    public GameObject ranksTextTMP;
    public GameObject playerNamesTextTMP;
    public GameObject scoresTextTMP;

    private string m_playerName = "";
    private int m_playerId = 0;
    private int m_actualLevelId = 1;
    private string m_ranks;
    private string m_playerNames;
    private string m_scores;
    private const int m_numberOfLevels = 4;

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
        UpdatePlayerCredentials();
        GetLadderboardsFromDb();
        RenderLadderboards();
    }

    void GetLadderboardsFromDb()
    {
        // TODO Get ladderboards From database
        m_ranks = "1\n2\n3\n4\n5\n6\n7\n8\n9\n10\n...\n999";
        m_playerNames = "Guest\n" +
                        "PlayerPlayer\n" +
                        "Boss\n" +
                        "Over9000\n" +
                        "Im5th\n" +
                        "6thPlayer\n" +
                        "Lucky7\n" +
                        "HatefulEight\n" +
                        "NotLuckyNine\n" +
                        "FullStack\n" +
                        "\n" +
                        "YouAreHere";
        m_scores = "2000\n" +
                   "1987\n" +
                   "1842\n" +
                   "1751\n" +
                   "1545\n" +
                   "1423\n" +
                   "1256\n" +
                   "1222\n" +
                   "1123\n" +
                   "978\n" +
                   "\n" +
                   "27";
    }

    void RenderLadderboards()
    {
        levelsTextTMP.GetComponent<TMP_Text>().text = "LEVEL " + m_actualLevelId;
        ranksTextTMP.GetComponent<TMP_Text>().text = m_ranks;
        playerNamesTextTMP.GetComponent<TMP_Text>().text = m_playerNames;
        scoresTextTMP.GetComponent<TMP_Text>().text = m_scores;
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
        GetLadderboardsFromDb();
        RenderLadderboards();
    }

    public void NextLevelButtonClicked()
    {
        Debug.Log("NextLevelButtonClicked()");
        incrementLevelId();
        GetLadderboardsFromDb();
        RenderLadderboards();
    }


}
