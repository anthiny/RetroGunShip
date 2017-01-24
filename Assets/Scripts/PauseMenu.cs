using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	public GameObject PauseUI;
	public Text bestScoreText;
	private bool paused = false;

	void Start(){
		bestScoreText.text = "Best Score : 0";
		PauseUI.SetActive (false);
	}

	void Update(){
		if (Input.GetButtonDown ("Pause")) {
			int bestScore = ScoreManager.instance.getBestScore();
			bestScoreText.text = "Best Score : " + bestScore.ToString();
			paused = !paused;
		}
		if (paused) {
			PauseUI.SetActive (true);
			
			Time.timeScale = 0;
		} else {
			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}
	}

	public void Resume(){
		paused = false;
	}

	public void Restart(){
		SceneManager.LoadScene ("Scene/InGame");
	}

	public void MainMenu(){
		SceneManager.LoadScene("Scene/Main");
	}

	public void Quit(){
		Application.Quit ();
	}
}
