using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : Singleton<GameManager1>
{
    public Rock[] RockPrefabs;
    public HeroMovement m_hero;
    public Object HousePrefabs;
    public Object Barrier;

    int m_score;
    bool m_isGameover;
    bool m_isGamebegun;

    public int Score { get => m_score; set => m_score = value; }
    public bool IsGameover { get => m_isGameover; set => m_isGameover = value; }
    public bool IsGamebegun { get => m_isGamebegun; }

    public override void Awake()
    {
        MakeSingleton(false);
    }

    
    public override void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            GameGUIManager.Ins.ShowHomeGui(true);
        }
        else
        {
            PlayGame();
        }
    }
    

    public void PlayGame()
    {
        StartCoroutine(Spawn());
        GameGUIManager.Ins.ShowHomeGui(false);
    }

    IEnumerator Spawn()
    {

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            yield return new WaitForSeconds(3f);
        }

        m_isGamebegun = true;

        if (RockPrefabs != null && RockPrefabs.Length > 0)
        {
            while (!m_isGameover && Score < 29)
            {
                int randIndex = Random.Range(0, RockPrefabs.Length);

                if (RockPrefabs[randIndex] != null)
                {
                    //Instantiate: tao ra 1 doi tuong tren scenes
                    Instantiate(RockPrefabs[randIndex], new Vector3(m_hero.transform.position.x, Random.Range(6f, 9f), 0f), Quaternion.identity);
                }
                if(Score < 10)
                    yield return new WaitForSeconds(1f);
                else if (Score < 20)
                    yield return new WaitForSeconds(0.75f);
                else
                    yield return new WaitForSeconds(0.5f);
            }
        }

        Destroy(Barrier);

        yield return null;
    }

}
