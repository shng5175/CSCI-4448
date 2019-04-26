using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class MainMenu : Menu {

    //public string playGameLevel;

	public virtual void Play()
    {
        Application.LoadLevel(level);
    }

    public virtual void End()
    {
        Application.Quit();
    }
}
