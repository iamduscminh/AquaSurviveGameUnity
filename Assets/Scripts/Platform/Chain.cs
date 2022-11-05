using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Chain : MonoBehaviour
{
   
    Rigidbody2D rb2d;
    public float velocityThreshold;
    public float leftAngle;
    public float rightAngle;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.angularVelocity = velocityThreshold;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }
/*    public void ChangeMoveDir()
    {
        if(transform.rotation.z > rightAngle)
        {
            movingClockwise = false;
        }
        if (transform.rotation.z < rightAngle)
        {
            movingClockwise = true;
        }
    }*/
    public void Move()
    {
        if (transform.rotation.z > 0 && transform.rotation.z < rightAngle
            && (rb2d.angularVelocity > 0) && rb2d.angularVelocity < velocityThreshold)
        
            {
            rb2d.angularVelocity = velocityThreshold;
            }
        else if(transform.rotation.z < 0 && transform.rotation.z > leftAngle
            && (rb2d.angularVelocity < 0) && rb2d.angularVelocity > velocityThreshold)
        {
            rb2d.angularVelocity = velocityThreshold * -1;
        }
    }
    

}
