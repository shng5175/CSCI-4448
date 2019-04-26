using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private int scoreToGive = 5;

    private ScoreManager theScore;

	// Use this for initialization
	void Start () {
        theScore = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == "Player"){
            theScore.scoreCount += scoreToGive;
            gameObject.SetActive(false);
        }
    }
}
