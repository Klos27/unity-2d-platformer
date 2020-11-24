using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Database_Utils;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    private enum State { idle, running, jumping, falling };
    private State state = State.idle;
    bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    [SerializeField] private LayerMask ground = 0;
    private Vector3 startingPos;

    private int xVector = 8;
    private int yVector = 60;

    private int coin20Points = 20;
    private int coin10Points = 10;

    private const int maxLevelTimeInSeconds = 120;
    private int levelTimeLeftInSeconds = maxLevelTimeInSeconds;

    [SerializeField] private int coinPoints = 0;
    [SerializeField] private TMP_Text timerText = null;
    [SerializeField] private TMP_Text pointsText = null;
    [SerializeField] private AudioSource footstepSound;
    [SerializeField] private AudioSource jumpSound;

    // End game panel
    [SerializeField] private GameObject endGamePanel = null;
    [SerializeField] private TMP_Text endGamePointsValueText = null;
    [SerializeField] private TMP_Text endGameTimeLeftValueText = null;
    [SerializeField] private TMP_Text endGamePointsMultiplierValueText = null;
    [SerializeField] private TMP_Text endGameFinalScoreValueText = null;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        startingPos = GameObject.Find("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.IsGamePaused())
        {
            UpdateTimerText();
            Movement();
            AnimatoinState();
            anim.SetInteger("state", (int)state);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // TODO Delete this after implementation of end game chest!
                // END GAME HACK - press Q
                EndGame();
            }
        }
    }
    void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);

        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-xVector, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(xVector, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, yVector);
            state = State.jumping;
        }
    }
    void AnimatoinState()
    {
        if (state == State.jumping)
        {
            if (rb.velocity.y < 1f)
            {
                state = State.falling;
            }
        }
        else if (state == State.falling)
        {
            if (isGrounded)
            {
                state = State.idle;
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }

        if (!coll.IsTouchingLayers(ground) && state != State.jumping)
        {
            state = State.falling;
        }
    }

    void UpdateTimerText()
    {
        float actualTime = Time.timeSinceLevelLoad;
        levelTimeLeftInSeconds = maxLevelTimeInSeconds - (int)(actualTime);

        if (levelTimeLeftInSeconds < 0)
            levelTimeLeftInSeconds = 0;

        int minutes = levelTimeLeftInSeconds / 60;
        int seconds = levelTimeLeftInSeconds % 60;
        timerText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    void UpdatePointsText()
    {
        pointsText.text = "Points: " + coinPoints.ToString("0000");
    }

    void EndGame()
    {
        FindObjectOfType<AudioManager>().Play("EndGameChestCollected");

        // Stop time
        PauseMenu.EndGame();

        // Show end game panel
        endGamePanel.SetActive(true);

        // Count final score
        endGamePointsValueText.text = coinPoints.ToString("0000");
        int minutes = levelTimeLeftInSeconds / 60;
        int seconds = levelTimeLeftInSeconds % 60;
        endGameTimeLeftValueText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        int scoreMultiplier = GetEndGameMultiplier();
        endGamePointsMultiplierValueText.text = "x" + scoreMultiplier.ToString("00");

        int finalScore = scoreMultiplier * coinPoints;
        endGameFinalScoreValueText.text = finalScore.ToString("0000");

        string sceneName = SceneManager.GetActiveScene().name;
        int worldId = int.Parse(sceneName.Substring(6)); // Substring Level_<level_number>

        StartCoroutine(updateScore(PlayerPrefs.GetInt("playerId"), worldId, finalScore));
    }

    private IEnumerator updateScore(int playerId, int worldId, int finalScore)
    {
        Database_Utils databaseUtils = new Database_Utils();
        CoroutineWithData cd = new CoroutineWithData(this, databaseUtils.UpdateScore(playerId, worldId, finalScore));
        yield return cd.coroutine;
        string updateScoreReceivedMessage = (string)cd.result;
        if ("0".Equals(updateScoreReceivedMessage))
        {
            Debug.Log("Player score updating has been successfully executed");
        }
        else
        {
            Debug.LogError(updateScoreReceivedMessage);
        }
    }

    public void ExitButtonClicked()
    {
        // Exit Game
        PauseMenu.Exit();
    }

    int GetEndGameMultiplier()
    {
        if (levelTimeLeftInSeconds >= maxLevelTimeInSeconds - (int)80)
            return 10;
        else if (levelTimeLeftInSeconds >= maxLevelTimeInSeconds - (int)100 &&
                levelTimeLeftInSeconds <  maxLevelTimeInSeconds - (int)80)
            return 8;
        else if (levelTimeLeftInSeconds >= maxLevelTimeInSeconds - (int)120 &&
                levelTimeLeftInSeconds < maxLevelTimeInSeconds - (int)100)
            return 6;
        else if (levelTimeLeftInSeconds >= maxLevelTimeInSeconds - (int)160 &&
                levelTimeLeftInSeconds < maxLevelTimeInSeconds - (int)120)
            return 3;
        else
            return 1;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Coin20P")
        {
            Destroy(collider.gameObject);
            FindObjectOfType<AudioManager>().Play("Coin20PCollected");
            coinPoints += coin20Points;
            UpdatePointsText();
        }
        else if (collider.tag == "Coin10P")
        {
            Destroy(collider.gameObject);
            FindObjectOfType<AudioManager>().Play("Coin10PCollected");
            coinPoints += coin10Points;
            UpdatePointsText();
        }
        else if (collider.tag == "EndGameChest")
        {
            EndGame();
        }
        else if (collider.tag == "spikes")
        {
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spikes_Hor_D")
        {
            if (state == State.falling || state == State.jumping)
            {
                if (collision.gameObject.transform.position.y <= transform.position.y)
                {
                    Die();
                }
            }

        }
        else if (collision.gameObject.tag == "Spikes_Hor_U")
        {
            if (state == State.falling || state == State.jumping)
            {
                if (collision.gameObject.transform.position.y >= transform.position.y)
                {
                    Die();
                }
            }

        }
        else if (collision.gameObject.tag == "Spikes_Vert_L")
        {
            if (state == State.falling || state == State.jumping || state == State.running)
            {
                if (collision.gameObject.transform.position.x <= transform.position.x)
                {
                    Die();
                }
            }

        }
        else if (collision.gameObject.tag == "Spikes_Vert_R")
        {
            if (state == State.falling || state == State.jumping || state == State.running)
            {
                if (collision.gameObject.transform.position.x >= transform.position.x)
                {
                    Die();
                }
            }

        }

    }

    void Die()
    {
        FindObjectOfType<AudioManager>().Play("GameOver");
        rb.position = new Vector2(startingPos.x, startingPos.y);
    }

    void Footstep()
    {
        footstepSound.Play();
    }

    void Jump()
    {
        jumpSound.Play();
    }
}