using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetType() == typeof(BoxCollider2D))
        {
            target.GetComponent<Health>().TakeDamage(0.5f);
        }
        if (collision.collider.GetType() == typeof(CapsuleCollider2D))
        {
            Destroy(gameObject);
        }
    }
}
