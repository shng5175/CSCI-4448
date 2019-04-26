using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerControl thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScore;

    public DeathMenu theDeathMenu;

    public NextLevelMenu theNextLevel;

	// Use this for initialization
	void Start () {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScore = FindObjectOfType<ScoreManager>();

        theDeathMenu.gameObject.SetActive(false);
        theNextLevel.gameObject.SetActive(true);

    }

    public void Restart(){
        theScore.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);

        theDeathMenu.gameObject.SetActive(true);

        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        theDeathMenu.gameObject.SetActive(false);
        platformList = FindObjectsOfType<PlatformDestroyer>();

        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }


        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScore.scoreCount = 0;
        theScore.scoreIncreasing = true;
    }

    /*public IEnumerator RestartGameCo(){
        theScore.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.5f);

        platformList = FindObjectsOfType<PlatformDestroyer>();

        for (int i = 0; i < platformList.Length; i++){
            platformList[i].gameObject.SetActive(false);
        }


        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScore.scoreCount = 0;
        theScore.scoreIncreasing = true;*/
    //}
}
