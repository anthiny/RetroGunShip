using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultPopUpController : MonoBehaviour {
	public GameObject resultTitleText;
	public GameObject scoreText;
	public GameObject bestScoreText;
	public GameObject score;
	public GameObject bestScore;
	public GameObject backToMain;
	// Use this for initialization
	void Start () {
		resultTitleText.GetComponentInChildren<FontInfo>().FontLoad();
		scoreText.GetComponentInChildren<FontInfo>().FontLoad();
		bestScoreText.GetComponentInChildren<FontInfo>().FontLoad();
		backToMain.GetComponentInChildren<FontInfo>().FontLoad();
		this.gameObject.SetActive(false);
	}
	public void ShowScoreInfo(){
		score.GetComponentInChildren<FontInfo>().text = (ScoreController.instance.GetScore()).ToString();
		score.GetComponentInChildren<FontInfo>().FontLoad();
		bestScore.GetComponentInChildren<FontInfo>().text = (ScoreController.instance.getBestScore()).ToString();
		bestScore.GetComponentInChildren<FontInfo>().FontLoad();
	}
	public void GoToMain(){
		SceneManager.LoadScene(0);
		SoundManager.instance.mainSwitch("mainMenu", true);
	}

}
