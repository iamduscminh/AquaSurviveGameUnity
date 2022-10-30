using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float distance;
    private bool moveRight = true;
    public Transform groundDetection;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D ground = Physics2D
            .Raycast(groundDetection.position, Vector2.down, distance);
        if(ground.collider == false)
        {
            if(moveRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            } else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (moveRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }
    }
}
