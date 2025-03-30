using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Speed")]
    public float runSpeed = 6f;
    public float jumpForce = 9f;

    [Header("Double Jump")]
    public float doubleJumpForce = 8f;
    private bool doubleJump;

    [Header("Dash")]
    public float dashCooldown;
    public float dashSpeed;
    public GameObject dashEffect;
    public float dashEffectDuration = 0.5f; 

    Rigidbody2D rb2D;

    public SpriteRenderer spriteRenderer;
    public Animator animator;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManager>();
    }
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator.Play("Appear");
    }


    private void Update()
    {
        dashCooldown -= Time.deltaTime;

        HandleJump();
        HandleAnimation();
    }
    private void FixedUpdate()
    {
        bool isDashing = Input.GetKey("left shift") && dashCooldown <= 0;

        if (isDashing)
        {
            PerformDash();
            dashEffect.SetActive(true);
        }
        else
        {
            HandleMovement();
        }
    }


    private void HandleJump()
    {
        if (Input.GetKey("space"))
        {
            if (CheckGround.isGrounded)
            {
                doubleJump = true;
                audioManager.PlaySFX(audioManager.jump);
                rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpForce);
            }
            else if (Input.GetKeyDown("space") && doubleJump)
            {
                animator.SetBool("DoubleJump", true);
                audioManager.PlaySFX(audioManager.jump);
                rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, doubleJumpForce);
                doubleJump = false;
            }
        }
    }
    private void HandleMovement()
    {
        float moveDirection = 0;
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            moveDirection = runSpeed;
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            moveDirection = -runSpeed;
            spriteRenderer.flipX = true;
        }
        rb2D.linearVelocity = new Vector2(moveDirection, rb2D.linearVelocity.y);
        animator.SetBool("Run", moveDirection != 0);
    }
    private void HandleAnimation()
    {
        if (!CheckGround.isGrounded)
        {
            animator.SetBool("Jump", rb2D.linearVelocity.y > 0);
            animator.SetBool("Fall", rb2D.linearVelocity.y < 0);
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Fall", false);

            bool isRunning = Input.GetKey("d") || Input.GetKey("right") || Input.GetKey("a") || Input.GetKey("left");
            animator.SetBool("Run", isRunning);
        }
    }


    private void PerformDash()
    {
        float dashDirection = spriteRenderer.flipX ? -dashSpeed : dashSpeed;
        rb2D.linearVelocity = new Vector2(dashDirection, rb2D.linearVelocity.y);
        audioManager.PlaySFX(audioManager.dash);
        dashCooldown = 5;

        StartCoroutine(StopDash());
    }
    IEnumerator StopDash()
    {
        yield return new WaitForSeconds(0.3f);
        rb2D.linearVelocity = new Vector2(0, rb2D.linearVelocity.y);
        dashEffect.SetActive(false);
    }
}

