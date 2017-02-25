using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonController : MonoBehaviour {
	public GameObject leaderBoardPopUp;
	void Start(){
		Time.timeScale = 1;
	}
	public void StartButton(){
		SoundManager.instance.mainSwitch("mainMenu", false);
		SceneManager.LoadScene("Scene/InGame");
	}

	public void ExitButton(){
		Application.Quit();
	}

	public void ShowLeaderBoardButton(){
		NetworkManager.instance.Login(CallGetLeaderBoardApi, LoginFail);
	}

	private void CallGetLeaderBoardApi(){
		NetworkManager.instance.GetLeaderBoardData(GetLeaderBoardDataSuccess, GetLeaderBoardDataFail);
	}

	private void LoginFail(){
		Debug.Log("LoginFail");
	}
	private void GetLeaderBoardDataSuccess(){
		Debug.Log("LeaderBoardOpen");
		leaderBoardPopUp.SetActive(true);
		leaderBoardPopUp.GetComponent<LeaderBoardController>().SettingBoard();
	}

	private void GetLeaderBoardDataFail(){

	}
}