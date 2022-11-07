using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int powerLove = 0;
    public LayerMask enemyLayers;


    //FireBall
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    private HeroMovement heroMovement;
    private float cooldownTimer = Mathf.Infinity;

    private Health enemyHealth;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && cooldownTimer > attackCooldown)
        {
            Punch();
        }
        if (Input.GetKeyDown(KeyCode.K) && cooldownTimer > attackCooldown)
        {
            Cut();
        }
        if (Input.GetKeyDown(KeyCode.L) && cooldownTimer > attackCooldown)
            SuperPunch();
        if (Input.GetKeyDown(KeyCode.U) && cooldownTimer > attackCooldown)
            Unlock();

        cooldownTimer += Time.deltaTime;

    }

    private void SuperPunch()
    {
        animator.SetTrigger("isSuperPunch");
        cooldownTimer = 0;
        if (powerLove > 3)
        {
            fireballs[FindFireball()].transform.position = firePoint.position;
            fireballs[FindFireball()].GetComponent<FireBall>().SetDirection(Mathf.Sign(transform.localScale.x));
        }
    }
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    // Update is called once per frame

    void Punch()
    {
        animator.SetTrigger("isPunch");
        Collider2D[] attackEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D attackEnemy in attackEnemies)
        {
            attackEnemy.GetComponent<HealthEnemy>().TakeDamage(1);
        }
    }

    void Cut()
    {
        animator.SetTrigger("isCut");
        Collider2D[] attackEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D attackEnemy in attackEnemies)
        {
            attackEnemy.GetComponent<HealthEnemy>().TakeDamage(1);
        }
    }
    void Unlock()
    {
        animator.SetTrigger("isUnlock");
        Collider2D[] attackEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D attackEnemy in attackEnemies)
        {
            //if (attackEnemy.tag == "Prison" && this.powerLove == 1)
            if (attackEnemy.tag == "Prison" )
            {
                Destroy(attackEnemy.gameObject);
                StartCoroutine(EndGame());
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2f);
        GameGUIManager.Ins.ShowGameEndGui(true);
    }
}
