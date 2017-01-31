using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	private static ScoreManager _instance = null;
	private int score = 0;
	private int maxScore = 0;
	public Text scoreText;
	bool isEnd = false;
	public static ScoreManager instance{
		get{
			if(!_instance){
				_instance = FindObjectOfType(typeof(ScoreManager)) as ScoreManager;
				if(!_instance){
					GameObject container = new GameObject();
					container.name = "ScoreModelContainer";
					_instance = container.AddComponent(typeof(ScoreManager)) as ScoreManager;
				}
			}
			return _instance;
		}
	}
	public void SetScore(int value){
		if(!isEnd){
			score = value;
			scoreText.text = "Score: " + value.ToString();
		}
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
}
