using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform EnemyTransform;
    private GameObject player;
    private Rigidbody2D rb;
    public float moveSpeed = 3f;
    private Vector2 movement;

    //References
    private Animator anim;
    void Start()
    {
        // Vì preFab ko cho g?n game obj ? bên ngoài nên ta s? khai báo private ?? x? lý trong code
        player = GameObject.Find("Hero"); //tim game obj can duoi theo
        EnemyTransform = player.transform; //ep lai kieu
        rb = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector3 direction = EnemyTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        //anim.SetBool("isRun", true);
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
