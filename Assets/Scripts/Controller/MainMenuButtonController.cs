using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonController : MonoBehaviour {
	public Text checkId;
	void Start(){
		checkId .text = "Loging...";
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
		NetworkManager.instance.GetLeaderBoardData();
	}

	private void LoginSuccess(){
		Debug.Log("LoginSuccess");
		checkId.text = NetworkManager.instance.getId();
	}
	private void LoginFail(){
		Debug.Log("LoginFail");
		checkId.text = "Fail";
	}
}