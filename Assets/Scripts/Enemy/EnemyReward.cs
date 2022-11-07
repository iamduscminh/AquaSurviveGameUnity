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
        //if (Enemy1 != null)
        //    ActiveReward(Enemy1, Reward1);
        //if (Enemy2 != null)
        //    ActiveReward(Enemy2, Reward2);
        //if (Enemy3 != null)
        //    ActiveReward(Enemy3, Reward3);

        //if (Enemy4 != null)
        //{
        //    Debug.Log("alive"+ "--"+ Enemy4.activeSelf);
        //    ActiveReward(Enemy4, Reward4);
        //}else { 
        //    Debug.Log("die"+ "--"+ Enemy4.activeSelf); }
        if (Enemy != null && !Enemy.activeSelf)
        {
            Reward.SetActive(true);
        }


    }
    //private void ActiveReward(GameObject Enemy, GameObject Reward)
    //{
    //    if (Enemy != null && !Enemy.activeSelf)
    //    {
    //        Reward.SetActive(true);
    //    }
    //}
}
