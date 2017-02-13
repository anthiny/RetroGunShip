using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePopUpController : MonoBehaviour {
	public Text bestScoreText;
	public bool paused = false;

	void Start(){
		bestScoreText.text = "Best Score : 0";
		this.gameObject.SetActive (false);
	}
	public void Pause(){
		int bestScore = ScoreModel.instance.getBestScore();
		bestScoreText.text = "Best Score : " + bestScore.ToString();
		paused = !paused;
	}
	public void Resume(){
		this.gameObject.SetActive(false);
		Time.timeScale = 1;
		paused = false;
	}

	public void Restart(){
		Time.timeScale = 1;
		SceneManager.LoadScene ("Scene/InGame");
	}

	public void MainMenu(){
		Time.timeScale = 1;
		SceneManager.LoadScene("Scene/Main");
	}

	public void Quit(){
		Application.Quit ();
	}
}
