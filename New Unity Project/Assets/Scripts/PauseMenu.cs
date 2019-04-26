using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PauseMenu : Menu {

    public GameObject pauseMenu;

    public void Restart()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().Reset();
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(level);
    }

    public virtual void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public virtual void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
}
