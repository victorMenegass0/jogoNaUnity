using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer sprite;

    public Transform groundCheck;

    private float hforce;
    private bool facingRight = false;
    private bool grounded;


    public float speed = 10f;
    public float jumpForce = 150f;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("ground"));
        hforce = Input.GetAxisRaw("Horizontal");
        if ((hforce > 0 && !facingRight) || (hforce < 0 && facingRight))
        {
            Flip();
        }
        if (grounded && Input.GetButtonDown("Jump"))
        {
            jump();
        }
    }
    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(hforce * speed, rb2d.velocity.y);
    }
    void Flip()
    {
        facingRight = !facingRight;
        sprite.flipX = !sprite.flipX;

    }
    void jump()
    {
        rb2d.AddForce(Vector2.up * jumpForce);
    }
}
