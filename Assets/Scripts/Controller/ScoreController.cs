using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	private static ScoreController _instance = null;
	private int score = 0;
	private float cnt = 0.0f;
	private int maxScore = 0;
	public Text scoreText;
	public bool isGameStart = false;

	void Update(){
		if(isGameStart){
			cnt = cnt + Time.timeScale;
		}
	}
	public static ScoreController instance{
		get{
			if(!_instance){
				_instance = FindObjectOfType(typeof(ScoreController)) as ScoreController;
				if(!_instance){
					GameObject container = new GameObject();
					container.name = "ScoreModelContainer";
					_instance = container.AddComponent(typeof(ScoreController)) as ScoreController;
				}
			}
			return _instance;
		}
	}

	public void DisplayScore(){
		scoreText.text = "Score: "+ score.ToString();
	}
	public void SetScore(int value){
		score = value;
		DisplayScore();
	}
	public int GetScore(){
		return score;
	}

	public void SaveBestScore(){
		maxScore = PlayerPrefs.GetInt("MaxScore");
		if (maxScore < score){
			PlayerPrefs.SetInt("MaxScore", score);
			maxScore = PlayerPrefs.GetInt("MaxScore");
		}
	}

	public int getBestScore(){
		SaveBestScore();
		return maxScore;
	}
	
	public void addScore(int value){
		score = score + value;
		DisplayScore();
	}
}
