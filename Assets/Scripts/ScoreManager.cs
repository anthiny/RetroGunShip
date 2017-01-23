using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
	private static ScoreManager _instance = null;
	private int score = 0;
	private int maxScore = 0;
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
		score = value;
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
