using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	private float lastUpdate;
	private int score;
	public Text pointsText;
	void Start(){
		score = 0;
	} 
	void Update(){
		if(Time.time - lastUpdate >= 1f){
			lastUpdate = Time.time;
			score += 1;
			displayScore(score);
		}
	}

	public void displayScore(int score){
		pointsText.text = ("Score: " + score);
	}
}
