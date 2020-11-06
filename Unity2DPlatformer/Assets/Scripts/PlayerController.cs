using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    private enum State { idle, running, jumping, falling };
    private State state = State.idle;
    [SerializeField] private LayerMask ground;

    private int xVector = 7;
    private int yVector = 40;

    private int coin20Points = 20;
    private int coin10Points = 10;

    private const int maxLevelTimeInSeconds = 120;
    private int levelTimeLeftInSeconds = maxLevelTimeInSeconds;

    [SerializeField] private int coinPoints = 0;
    [SerializeField] private TMP_Text timerText = null;
    [SerializeField] private TMP_Text pointsText = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
		if(!PauseMenu.isGamePaused())
        {
			Movement();
			AnimatoinState();
			anim.SetInteger("state", (int)state);
		}
    }
    void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");

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
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
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
            if (coll.IsTouchingLayers(ground))
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin20P")
        {
            Destroy(collision.gameObject);
            coinPoints += coin20Points;
            UpdatePointsText();
        } 
        else if (collision.tag == "Coin10P")
        {
            Destroy(collision.gameObject);
            coinPoints += coin10Points;
            UpdatePointsText();
        }
    }
}