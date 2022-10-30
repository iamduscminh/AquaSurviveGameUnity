using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBehavior : MonoBehaviour
{
    public GameObject target;
    public float speed = 0.5f;
    public Transform pos_1;
    public bool isUnlock;

    private void Update()
    {
        if (isUnlock)
        {
            target.transform.position = Vector3.MoveTowards(target.transform.position
                          , pos_1.position
                          , speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Key"))
        {
            isUnlock = true;
        }
    }

}
