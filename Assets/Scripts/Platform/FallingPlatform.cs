using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
        if(collision.gameObject.CompareTag("GrassGround") || collision.gameObject.CompareTag("Platform") ||
            collision.gameObject.CompareTag("FallingPlatform"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.09f);
        rigidbody.isKinematic = false;
    }
}
