using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformMovement : MonoBehaviour
{
    public Transform pos_1, pos_2;
    public float speed;
    public Transform startPos;
    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pos_1.position)
        {
            nextPos = pos_2.position;
        }
        if (transform.position == pos_2.position)
        {
            nextPos = pos_1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position
                                                , nextPos
                                                , speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos_1.position, pos_2.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (SceneManager.GetActiveScene().name == "Scene2")
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.transform.SetParent(transform);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (SceneManager.GetActiveScene().name == "Scene2")
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.transform.SetParent(null);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
