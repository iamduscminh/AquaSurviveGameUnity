using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireballHolder : MonoBehaviour
{
    [SerializeField] private Transform enemy;

    private void Update()
    {
        Debug.Log($"Enemy: {enemy.localScale} --- Fire : {transform.localScale}" );
        
    }
}
