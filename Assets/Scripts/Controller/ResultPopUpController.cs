using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class ResultPopUpController : MonoBehaviour {
	public GameObject resultTitleText;
	public GameObject scoreText;
	public GameObject score;
	public GameObject backToMain;
	public GameObject UploadScore;
	void Start () {
		resultTitleText.GetComponentInChildren<FontInfo>().FontLoad();
		scoreText.GetComponentInChildren<FontInfo>().FontLoad();
		backToMain.GetComponentInChildren<FontInfo>().FontLoad();
		UploadScore.GetComponentInChildren<FontInfo>().FontLoad();
		this.gameObject.SetActive(false);
		PopUpManager.instance.OverlaySwitch(false);
	}
	public void ShowScoreInfo(){
		score.GetComponentInChildren<FontInfo>().text = "";
		score.GetComponentInChildren<FontInfo>().text = (ScoreModel.instance.GetScore()).ToString();
		score.GetComponentInChildren<FontInfo>().FontLoad();
	}
	public void GoToMain(){
		PopUpManager.instance.ChangeOverlayText("Success...");
		if (Advertisement.IsReady())
    	{
      		Advertisement.Show();
    	}
		SceneManager.LoadScene(0);
		SoundManager.instance.mainSwitch("mainMenu", true);
	}

	public void ScoreUpLoading(){
		Debug.Log("Try to check before upload");
		if(NetworkManager.instance.LoginCheck())
		{
			if(string.IsNullOrEmpty(NetworkManager.instance.getNickName())){
				Debug.Log("Show Input NickName PopUp!");
				PopUpManager.instance.OverlaySwitch(false);
				PopUpManager.instance.ShowInputNickNamePopUp();
			}
			else{
				Debug.Log("CallSocreUpLoadApi");
				PopUpManager.instance.OverlaySwitch(true);
				CallSocreUpLoadApi();
			}
		}
		else{
			PopUpManager.instance.OverlaySwitch(true);
			PopUpManager.instance.ChangeOverlayText("Try to Login...");
			NetworkManager.instance.Login(ScoreUpLoading, ShowLoginFailMessage);
		}
	}
	private void CallSocreUpLoadApi(){
		PopUpManager.instance.ChangeOverlayText("UpLoading Score...");
		NetworkManager.instance.UploadScore(GoToMain, ShowSocreUpLoadingFailMessage, ScoreModel.instance.GetScore());
	}

	private void ShowLoginFailMessage(){
		PopUpManager.instance.OverlaySwitch(false);
		ErrorHandleManager.instance.CreateErrorPopUp("Login Fail");
	}

	private void ShowSocreUpLoadingFailMessage(){
		PopUpManager.instance.OverlaySwitch(false);
		ErrorHandleManager.instance.CreateErrorPopUp("Score UpLoading Fail");
	}
}
