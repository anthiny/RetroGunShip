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
		if(string.IsNullOrEmpty(inputField.text)){
			Debug.Log("Check your InputBox!!!!!");
			ErrorHandleManager.instance.CreateErrorPopUp("Plz Input at least 1 char");
			return;
		}
		PopUpManager.instance.OverlaySwitch(true);
		PopUpManager.instance.ChangeOverlayText("Add Nick Name ...");
		NetworkManager.instance.UpdateNickName(UploadScore, ShowAddNickNameFailMessage, inputField.text);
	}

	public void CancelButton(){
		this.gameObject.SetActive(false);
	}
	private void UploadScore(){
		Debug.Log("Uploading Score!!!");
		PopUpManager.instance.ChangeOverlayText("UpLoading Score...");
		NetworkManager.instance.UploadScore(ShowSuccessMessage, ShowUploadingScoreFailMessage, ScoreModel.instance.GetScore());
	}

	private void ShowSuccessMessage(){
		PopUpManager.instance.ChangeOverlayText("Success");
		this.gameObject.SetActive(false);
		PopUpManager.instance.OverlaySwitch(false);
		SceneManager.LoadScene(0);
		SoundManager.instance.mainSwitch("mainMenu", true);
	}
	private void ShowAddNickNameFailMessage(string errorStauts){
		Debug.Log("AddNickNameFail!");
		inputField.text = "";
		if (errorStauts.ToLower() != "namenotavailable"){
			ErrorHandleManager.instance.CreateErrorPopUp("Add Nick Name Fail");	
		}
		else{
			ErrorHandleManager.instance.CreateErrorPopUp(errorStauts);	
		}
		PopUpManager.instance.OverlaySwitch(false);
		this.gameObject.SetActive(false);
	}

	private void ShowUploadingScoreFailMessage(){
		Debug.Log("ScoreUpLoadingFail!");
		ErrorHandleManager.instance.CreateErrorPopUp("Score UpLoading Fail");
		PopUpManager.instance.OverlaySwitch(false);
		this.gameObject.SetActive(false);
	}
}
