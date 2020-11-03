﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator anim;

    private int xVector = 5;
    private int yVector = 10;

    private int coin20Points = 20;
    private int coin10Points = 10;

    [SerializeField] private int coinPoints = 0;
    [SerializeField] private Text coinPointsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-xVector, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            anim.SetBool("running", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(xVector, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, yVector);
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
