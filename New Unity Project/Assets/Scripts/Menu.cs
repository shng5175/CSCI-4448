using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class Menu : MonoBehaviour {

    public string level;

    public void Restart()
    {
        Application.LoadLevel(level);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
