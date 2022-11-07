using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float moveSpeed;

    Rigidbody2D m_rb;

    bool m_isGrounded;

    public bool IsGrounded { get => m_isGrounded; }

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (m_rb)
            m_rb.velocity = Vector3.down * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GrassGround"))
        {
            //m_isGrounded = true;
            Destroy(gameObject, 0.5f);

            //GameGUIManager.Ins.UpdateScoreCounting(GameManager.Ins.Score);
            //GameGUIManager.Ins.MoveNextScene(GameManager.Ins.Score);
            AudioController.Ins.PlaySound(AudioController.Ins.landSound);

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            //if (m_isDead) return;
            HeroMovement hero = collision.gameObject.GetComponent<HeroMovement>();
            hero.GetComponent<Health>().TakeDamage(0.5f);
            Destroy(gameObject, 0.5f);
            //GameManager.Ins.IsGameover = true;

            //GameGUIManager.Ins.ShowGameover(true);
            AudioController.Ins.PlaySound(AudioController.Ins.landSound);
        }
        GameManager1.Ins.Score++;
    }
}
