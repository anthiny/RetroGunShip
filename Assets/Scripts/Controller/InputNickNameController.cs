using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class InputNickNameController : MonoBehaviour {
	public InputField inputField;
	// Use this for initialization
	void Start () {
		this.gameObject.SetActive(false);
	}
	public void AddNickName(){
		if(!CheckInputBox()){
			Debug.Log("Check your InputBox!!!!!");
			return;
		}
		//NetworkManager.instance.Login(LoginSuccess, LoginFail);
		NetworkManager.instance.UpdateNickName(UploadScore, ShowFailMessage, inputField.text);
	}
	private void UploadScore(){
		Debug.Log("Uploading Score!!!");
		NetworkManager.instance.UploadScore(ShowSuccseeMessage, ShowFailMessage, ScoreModel.instance.GetScore());
	}
	private bool CheckInputBox(){
		if(inputField.text.Length > 0){
			return true;
		}
		else{
			return false;
		}
	}
	private void ShowSuccseeMessage(){
		this.gameObject.SetActive(false);
		SceneManager.LoadScene(0);
		SoundManager.instance.mainSwitch("mainMenu", true);
	}
	private void ShowFailMessage(){
		Debug.Log("fail!");
		this.gameObject.SetActive(false);
	}
}
