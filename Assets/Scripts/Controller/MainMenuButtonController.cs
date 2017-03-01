using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonController : MonoBehaviour {
	public GameObject leaderBoardPopUp;
	public GameObject loadingOverlay;
	void Start(){
		Time.timeScale = 1;
		OverlaySwitch(false);
	}
	public void StartButton(){
		SoundManager.instance.mainSwitch("mainMenu", false);
		SceneManager.LoadScene("Scene/InGame");
	}

	public void ExitButton(){
		Application.Quit();
	}

	public void ShowLeaderBoardButton(){
		OverlaySwitch(true);
		NetworkManager.instance.Login(CallGetLeaderBoardApi, LoginFail);
	}

	private void CallGetLeaderBoardApi(){
		NetworkManager.instance.GetLeaderBoardData(GetLeaderBoardDataSuccess, GetLeaderBoardDataFail);
	}

	private void LoginFail(){
		OverlaySwitch(false);
		ErrorHandleManager.instance.CreateErrorPopUp("Login Fail");
		Debug.Log("LoginFail");
	}
	private void GetLeaderBoardDataSuccess(){
		Debug.Log("LeaderBoardOpen");
		OverlaySwitch(false);
		leaderBoardPopUp.gameObject.SetActive(true);
		leaderBoardPopUp.GetComponent<LeaderBoardController>().SettingBoard();
	}

	private void OverlaySwitch(bool value){
		loadingOverlay.SetActive(value);
	}

	private void GetLeaderBoardDataFail(){
		OverlaySwitch(false);
		ErrorHandleManager.instance.CreateErrorPopUp("Get LeaderBoard Data Fail");
		Debug.Log("GetLeaderBoardDataFail");
	}
}