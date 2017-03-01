using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreModel : MonoBehaviour {
	private static ScoreModel _instance = null;
	private int score = 0;
	private int maxScore = 0;

	public static ScoreModel instance{
		get{
			if(!_instance){
				_instance = FindObjectOfType(typeof(ScoreModel)) as ScoreModel;
				if(!_instance){
					GameObject container = new GameObject();
					container.name = "ScoreModelContainer";
					_instance = container.AddComponent(typeof(ScoreModel)) as ScoreModel;
				}
			}
			return _instance;
		}
	}
	
	public int GetScore(){
		return score;
	}

	/*public void SaveBestScore(){
		maxScore = PlayerPrefs.GetInt("MaxScore");
		if (maxScore < score){
			PlayerPrefs.SetInt("MaxScore", score);
			maxScore = PlayerPrefs.GetInt("MaxScore");
		}
	}*/

	public int getBestScore(){
		//SaveBestScore();
		return maxScore;
	}
	
	public void addScore(int value){
		score = score + value;
	}
}
