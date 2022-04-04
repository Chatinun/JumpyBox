using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Object References")]
    public Rigidbody2D rb;

    [Header("Basic Movement")]
    public float speed;
    public float jumpForce;

    private float moveInput;
    private bool facingRight = true;
    public bool doubleJump;
    private bool isDead;
    public bool isImmune;

    [Header("Animation")]
    public Animator playerAnim;

    [Header("Grounded")]
    public float checkRadius;
    public Transform groundCheck;
    public LayerMask layerGround;
    public bool isGrounded;

    [Header("Hang Time")]
    public float hangTime;
    private float hangCounter;

    [Header("Effect")]
    [SerializeField] private GameObject jumpEffect;
    [SerializeField] private GameObject deadEffect;

    [Header("Wall Jump")]
    public bool canWallJump;
    public float wallJumpTime = 0.2f;
    public float wallSlideSpeed = 0.3f;
    public float wallDistance = 0.5f;
    bool isWallSliding = false;
    RaycastHit2D WallCheckHit;
    float jumpTime;

    [Header("Input")]
    public bool disableInput = false;

    /*
    private bool isTouchingFront;
    public Transform frontCheck;
    private bool wallSliding;
    public float wallSlidingSpeed;

    private bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;
    */

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {   
        if(transform.position.y < -5.3f)
        {
            Dead();
        }

        if (!isDead && !GameManager.instance.isGameEnded && !disableInput)
        {
            //Check if is on ground
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, layerGround);

            //Hang time
            if (isGrounded)
            {
                hangCounter = hangTime;
                playerAnim.SetBool("OnGround", true);
            }
            else
            {
                hangCounter -= Time.deltaTime;
            }

            //Movement
            moveInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

            if (!facingRight && moveInput > 0)
            {
                Flip();
            }
            else if (facingRight && moveInput < 0)
            {
                Flip();
            }

            //Double jump
            if (isGrounded && !Input.GetButton("Jump"))
            {
                doubleJump = false;
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (isWallSliding && Input.GetButton("Jump"))
                {
                    rb.velocity = Vector2.up * jumpForce;
                    doubleJump = true;
                    rb.AddForce(new Vector2(-moveInput * 50, 0));
                    Instantiate(jumpEffect, new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), Quaternion.identity);
                }
                else if (hangCounter > 0 || doubleJump)
                {
                    playerAnim.SetBool("OnGround", false);
                    playerAnim.SetTrigger("Jump");
                    rb.velocity = Vector2.up * jumpForce;
                    doubleJump = !doubleJump;
                    Instantiate(jumpEffect, new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), Quaternion.identity);
                    AudioManager.instance.audioPlay("Jump");
                }
            }

            //High Jump
            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            //Wall Jumpy
            if (canWallJump)
            {
                if (facingRight)
                {
                    WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(wallDistance, 0), wallDistance, layerGround);
                }
                else
                {
                    WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(-wallDistance, 0), wallDistance, layerGround);
                }

                if (WallCheckHit && !isGrounded && moveInput != 0)
                {
                    isWallSliding = true;
                }
                else
                {
                    isWallSliding = false;
                }

                if (isWallSliding)
                {
                    rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
                }
            }
            

        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Dead()
    {
        Instantiate(deadEffect, new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), Quaternion.identity);
        gameObject.SetActive(false);
        isDead = true;
        GameManager.instance.RestartScene();
        AudioManager.instance.audioPlay("Dead");
        GameManager.instance.TimerAddToTotal();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Killer")
        {
            if (!isImmune)
            {
                Dead();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Killer")
        {
            if (!isImmune)
            {
                Dead();
            }
        }
    }

}
