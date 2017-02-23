using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonController : MonoBehaviour {
	public GameObject leaderBoardPopUp;
	void Start(){
		NetworkManager.instance.Login(LoginSuccess, LoginFail);
	}
	public void StartButton(){
		SoundManager.instance.mainSwitch("mainMenu", false);
		SceneManager.LoadScene("Scene/InGame");
	}

	public void ExitButton(){
		Application.Quit();
	}

	public void ShowLeaderBoardButton(){
		NetworkManager.instance.GetLeaderBoardData(GetLeaderBoardDataSuccess, GetLeaderBoardDataFail);
	}

	private void LoginSuccess(){
		Debug.Log("LoginSuccess");
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