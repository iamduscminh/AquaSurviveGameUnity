using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy1, Enemy2;
   

    // Update is called once per frame
    void Update()
    {
        ActiveReward(Enemy1, Enemy2);
       
       
    }
    private void ActiveReward(GameObject Enemy, GameObject EnemyRp)
    {
        if (Enemy != null && !Enemy.activeSelf)
        {
            EnemyRp.SetActive(true);
        }
    }
}
