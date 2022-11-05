using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReward : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Reward;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("C");
        if(Enemy != null && !Enemy.activeSelf)
        {
            Debug.Log("D");
            Reward.SetActive(true);
        } 
    }
}
