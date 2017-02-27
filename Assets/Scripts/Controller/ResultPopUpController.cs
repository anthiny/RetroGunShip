﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
		score.GetComponentInChildren<FontInfo>().text = (ScoreModel.instance.GetScore()).ToString();
		score.GetComponentInChildren<FontInfo>().FontLoad();
	}
	public void GoToMain(){
		PopUpManager.instance.ChangeOverlayText("Success!!!!");
		SceneManager.LoadScene(0);
		SoundManager.instance.mainSwitch("mainMenu", true);
	}

	public void ScoreUpLoading(){
		Debug.Log("Try to check before upload");
		if(NetworkManager.instance.LoginCheck())
		{
			if(NetworkManager.instance.getNickName() == null){
				PopUpManager.instance.OverlaySwitch(false);
				PopUpManager.instance.ShowInputNickNamePopUp();
			}
			else{
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
		NetworkManager.instance.UploadScore(GoToMain, ShowSocreUpFailMessage, ScoreModel.instance.GetScore());
	}

	private void ShowLoginFailMessage(){
		PopUpManager.instance.OverlaySwitch(false);
	}

	private void ShowSocreUpFailMessage(){
		PopUpManager.instance.OverlaySwitch(false);
	}
}
