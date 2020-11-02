using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    private int xVector = 5;
    private int yVector = 10;
    public Animator anim;

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
}
