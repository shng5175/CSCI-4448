using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class DeathMenu : Menu {

    public void Restart()
    {
        FindObjectOfType<GameManager>().Reset();
    }

    public void Quit()
    {
        Application.LoadLevel(level);
    }
}
