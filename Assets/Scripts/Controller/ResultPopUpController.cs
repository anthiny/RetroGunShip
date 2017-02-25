using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultPopUpController : MonoBehaviour {
	public GameObject resultTitleText;
	public GameObject scoreText;
	public GameObject score;
	public GameObject backToMain;
	public GameObject UploadScore;
	public GameObject inputNickNamePopUp;
	// Use this for initialization
	void Start () {
		resultTitleText.GetComponentInChildren<FontInfo>().FontLoad();
		scoreText.GetComponentInChildren<FontInfo>().FontLoad();
		backToMain.GetComponentInChildren<FontInfo>().FontLoad();
		UploadScore.GetComponentInChildren<FontInfo>().FontLoad();
		this.gameObject.SetActive(false);
	}
	public void ShowScoreInfo(){
		score.GetComponentInChildren<FontInfo>().text = (ScoreModel.instance.GetScore()).ToString();
		score.GetComponentInChildren<FontInfo>().FontLoad();
	}
	public void GoToMain(){
		SceneManager.LoadScene(0);
		SoundManager.instance.mainSwitch("mainMenu", true);
	}

	public void ScoreUpLoading(){
		Debug.Log("Try to check before upload");
		if(NetworkManager.instance.getNickName() == null){
			inputNickNamePopUp.SetActive(true);
		}
		else{
			NetworkManager.instance.Login(CallSocreUpLoadApi, ShowFailMessage);
		}
	}
	private void CallSocreUpLoadApi(){
		NetworkManager.instance.UploadScore(GoToMain, ShowFailMessage, ScoreModel.instance.GetScore());
	}
	private void ShowFailMessage(){

	}
}
