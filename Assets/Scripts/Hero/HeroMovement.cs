using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool isPunch, isCut, isSuperPunch;
    Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Jump();
        Flip();
        //HandleAttackInput();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, -9f, 9f),
        transform.position.y,
        transform.position.z
        );
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isJump", true);

            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }
    private void HandleAttackInput()
    {
        if (Input.GetKeyDown(KeyCode.J)) isPunch = true;
        if (Input.GetKeyDown(KeyCode.K)) isCut = true;
        if (Input.GetKeyDown(KeyCode.L)) isSuperPunch = true;
    }
    private void AddAttackAnimation()
    {
        // Punch
        if (isPunch)
        {
            animator.SetTrigger("isPunch");
        }

        // Cut
        if (isCut)
        {
            animator.SetTrigger("isCut");
        }

        //Super Punch
        if (isSuperPunch)
        {
            animator.SetTrigger("isSuperPunch");
        }
    }
    private void ResetAnimationAttack()
    {
        isPunch = false;
        isCut = false;
        isSuperPunch = false;
    }
    private void FixedUpdate()
    {
        //Run
        animator.SetBool("isRun", horizontal != 0);
        if (horizontal == 0)
        {
            animator.SetBool("isRun", false);
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        //Attack
        //AddAttackAnimation();
        //ResetAnimationAttack();
    }

    private bool IsGrounded()
    {
        Debug.Log("IsGrounded");
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GrassGround"))
        {
            animator.SetBool("isJump", false);
        }
    }
}
