using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeroMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 5f;
    private float jumpingPower = 12f;
    private bool isFacingRight = true;
    private bool isPunch, isCut, isSuperPunch;
    Animator animator;
    string[] word = new string[5];
    string sort;
    string B = "B";
    string R = "R";
    string A = "A";
    string V = "V";
    string E = "E";
    [SerializeField] private Collider2D collider;
    bool isGround;
    bool isPush;
    bool isPlatform;
    /*    private int apples = 0;*/
    [SerializeField] private Text appleText;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask pushLayer;
    Stack<Vector3> heroPos = new Stack<Vector3>();
    Stack<string> checkPoint = new Stack<string>();
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
        rb.velocity = new Vector2(horizontal * speed,rb.velocity.y);
        
        if (isPlatform)
        {
            if (SceneManager.GetActiveScene().name == "Scene3")
            {
                speed = 8f;
                jumpingPower = 7f;
            }
            else
            {
                speed = 3.4f;
                jumpingPower = 7f;
            }
        }
        else if (!isPlatform)
        {
            speed = 6f;
            jumpingPower = 12f;
        }
        if (SceneManager.GetActiveScene().name == "Scene4")
        {
            speed = 8f;
            jumpingPower = 14f;
        }
        Jump();
        Flip();
        //HandleAttackInput();
        /*        if (SceneManager.GetActiveScene().buildIndex == 0)
                {
                    transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -9f, 9f),
                transform.position.y,
                transform.position.z
                );
                }*/
    }

    private void Jump()
    {
        isGround = collider.IsTouchingLayers(groundLayer);
        isPush = collider.IsTouchingLayers(pushLayer);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            //if (SceneManager.GetActiveScene().name )
            //{
            if (SceneManager.GetActiveScene().name == "Scene3")
            {
                if(isGround || isPush)
                {
                    animator.SetBool("isJump", true);
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                }    
            }
            else
            {
                if (isGround)
                {
                    animator.SetBool("isJump", true);
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                }
            }
            //}
            //else
            //{
            //    animator.SetBool("isJump", true);
            //    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            //}

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
            isPlatform = false;
        }
        if (collision.gameObject.CompareTag("Platform"))
        {
            rb.interpolation = RigidbodyInterpolation2D.None;
            animator.SetBool("isJump", false);
            isPlatform = true;

        }
        if (collision.gameObject.CompareTag("FallingPlatform"))
        {
            animator.SetBool("isJump", false);
            isPlatform = false;
        }
        if (SceneManager.GetActiveScene().name == "Scene3")
        {
            if (collision.gameObject.CompareTag("Saw"))
            {
                gameObject.GetComponent<Health>().TakeDamage(0.5f);

                transform.position = new Vector3(-9f, 0f, 0f);
            }
        }
        else
        {

            if (collision.gameObject.CompareTag("Saw"))
            {
                gameObject.GetComponent<Health>().TakeDamage(0.5f);
                if (SceneManager.GetActiveScene().buildIndex != 0)
                {
                    transform.position = heroPos.Peek();
                }
            }
        }

        
            if (SceneManager.GetActiveScene().name == "Scene3")
        {
            if (collision.gameObject.CompareTag("TrapFire"))
            {
                gameObject.GetComponent<Health>().TakeDamage(0.5f);
            }
        }
        if(SceneManager.GetActiveScene().name == "Scene2")
        {
            if(collision.gameObject.CompareTag("Button"))
            {
                Destroy(GameObject.Find("Button").gameObject);
                Destroy(GameObject.Find("KeyHolder").gameObject);
            }
            if (collision.gameObject.CompareTag("Patrol"))
            {
                if (collision.collider.GetType() == typeof(PolygonCollider2D))
                {
                    gameObject.GetComponent<Health>().TakeDamage(0.5f);
                }
            }
        }
    }
            

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* if (collision.gameObject.CompareTag("Apple"))
         {
             Destroy(collision.gameObject);
             apples++;
             appleText.text = "Apple: " + apples + "\n\n" + "Word: " + word;
         }*/

        if (collision.gameObject.CompareTag("Gate"))
        {
            heroPos.Clear();
            isPlatform = false;
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (sceneIndex == 2)
            {
                if (word[0] == B && word[1] == R && word[2] == A && word[3] == V && word[4] == E)
                {
                    SceneManager.LoadScene(sceneIndex + 1);
                }

            }
            else
            {
                SceneManager.LoadScene(sceneIndex + 1);
            }
        }

        if (collision.gameObject.CompareTag("TextB"))
        {
            word[0] = B;
            Destroy(collision.gameObject);

        }

        else if (collision.gameObject.CompareTag("TextR"))
        {
            word[1] = R;
            Destroy(collision.gameObject);

        }

        else if (collision.gameObject.CompareTag("TextA"))
        {
            word[2] = A;
            Destroy(collision.gameObject);

        }

        else if (collision.gameObject.CompareTag("TextV"))
        {
            word[3] = V;
            Destroy(collision.gameObject);

        }

        else if (collision.gameObject.CompareTag("TextE"))
        {
            word[4] = E;
            Destroy(collision.gameObject);

        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            word[0] = word[0] == null ? "?" : word[0];
            word[1] = word[1] == null ? "?" : word[1];
            word[2] = word[2] == null ? "?" : word[2];
            word[3] = word[3] == null ? "?" : word[3];
            word[4] = word[4] == null ? "?" : word[4];

            appleText.text = "Word: " + word[0] + " - " + word[1] + " - " + word[2] + " - " + word[3] + " - " + word[4];
        }

        if(collision.gameObject.CompareTag("CheckPoint"))
        {
            if(!checkPoint.Contains(collision.gameObject.name))
            {
                checkPoint.Push(collision.gameObject.name);
                Vector2 vector = new Vector2(transform.position.x, transform.position.y);
                heroPos.Push(vector);
            }
        }
    }
}
