using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] private int coinPoints = 0;
    [SerializeField] private Text coinPointsText;

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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin20P")
        {
            Destroy(collision.gameObject);
            coinPoints += coin20Points;
            coinPointsText.text = coinPoints.ToString();
        }
        else if (collision.tag == "Coin10P")
        {
            Destroy(collision.gameObject);
            coinPoints += coin10Points;
            coinPointsText.text = coinPoints.ToString();
        }
    }
}