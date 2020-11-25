using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool m_gameIsPaused = false;
    private static bool m_gameIsEnded = false;

    public GameObject pauseMenuUi;

    // Start is called before the first frame update
    void Start()
    {
        m_gameIsPaused = false;
        m_gameIsEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGameEnded())
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                FindObjectOfType<AudioManager>().Play("EscPressed");
                if (IsGamePaused())
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public static bool IsGamePaused()
    {
        return m_gameIsPaused;
    }

    public static bool IsGameEnded()
    {
        return m_gameIsEnded;
    }

    public static void EndGame()
    {
        m_gameIsPaused = true;
        m_gameIsEnded = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        m_gameIsPaused = false;
        FindObjectOfType<AudioManager>().PlayBackgroundMusic();
    }

    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f; // Choose something from 0f - 1f for slow motion, or over 1f for speed up
        m_gameIsPaused = true;
        FindObjectOfType<AudioManager>().PauseBackgroundMusic();
    }

    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        m_gameIsPaused = false;
        FindObjectOfType<AudioManager>().StopBackgroundMusic();
        FindObjectOfType<AudioManager>().PlayBackgroundMusic();
    }

    public static void Exit()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        m_gameIsPaused = false;
    }
}
