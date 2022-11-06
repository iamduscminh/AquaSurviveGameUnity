using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Reward : MonoBehaviour
{
    public TextMeshProUGUI MyscoreText;
    public int Scorenum;
    public GameObject hero;
    void Start()
    {
        Scorenum = 0;
        MyscoreText.text = "x " + Scorenum;
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Reward")
        {
            Scorenum++;
            Destroy(collision.gameObject);
            MyscoreText.text = "x " + Scorenum;
            hero.GetComponent<HeroAttack>().powerLove+=1;
        }      
    }
}
