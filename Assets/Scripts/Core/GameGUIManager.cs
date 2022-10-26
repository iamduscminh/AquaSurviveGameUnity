using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUIManager : Singleton<GameGUIManager>
{

    public Text scoreCountingText;
    public override void Awake()
    {
        MakeSingleton(false);
    }

    public void MoveNextScene(int score)
    {
        if(score == 10)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}
