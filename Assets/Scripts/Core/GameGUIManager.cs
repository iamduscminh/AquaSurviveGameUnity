using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUIManager : Singleton<GameGUIManager>
{

    public GameObject homeGui;
    public GameObject gameoverGui;

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public void ShowHomeGui(bool iShow)
    {
        if (homeGui)
            homeGui.SetActive(iShow);
    }

    public void ShowGameoverGui(bool iShow)
    {
        if (homeGui)
            homeGui.SetActive(iShow);
    }

    public void Play()
    {
        GameManager1.Ins.PlayGame();
    }

    public void Setting()
    {
       //do something here
    }

    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Application.Quit();
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    public void Home()
    {
        ShowGameoverGui(false);
        ShowHomeGui(true);
    }
}
