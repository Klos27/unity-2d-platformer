using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool m_gameIsPaused = false;

    public GameObject pauseMenuUi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused())
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public static bool isGamePaused()
    {
        return m_gameIsPaused;
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        m_gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f; // Choose something from 0f - 1f for slow motion
        m_gameIsPaused = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        m_gameIsPaused = false;
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        m_gameIsPaused = false;
    }
}
