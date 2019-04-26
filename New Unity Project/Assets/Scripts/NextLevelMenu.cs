using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class NextLevelMenu : Menu
{
    public GameObject nextMenu;
    public string nextLevel;

    public void Restart()
    {
        nextMenu.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().Reset();
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(level);
    }

    public virtual void Continue()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(nextLevel);
    }

    public virtual void Next()
    {
        Time.timeScale = 0f;
        nextMenu.SetActive(true);
    }

}
