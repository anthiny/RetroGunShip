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
		PopUpManager.instance.OverlaySwitch(true);
		PopUpManager.instance.ChangeOverlayText("Add Nick Name ...");
		NetworkManager.instance.UpdateNickName(UploadScore, ShowFailMessage, inputField.text);
	}

	public void CancelButton(){
		this.gameObject.SetActive(false);
	}
	private void UploadScore(){
		Debug.Log("Uploading Score!!!");
		PopUpManager.instance.ChangeOverlayText("UpLoading Score...");
		NetworkManager.instance.UploadScore(ShowSuccessMessage, ShowFailMessage, ScoreModel.instance.GetScore());
	}
	private bool CheckInputBox(){
		if(inputField.text.Length > 0){
			return true;
		}
		else{
			return false;
		}
	}
	private void ShowSuccessMessage(){
		PopUpManager.instance.ChangeOverlayText("Success");
		this.gameObject.SetActive(false);
		PopUpManager.instance.OverlaySwitch(false);
		SceneManager.LoadScene(0);
		SoundManager.instance.mainSwitch("mainMenu", true);
	}
	private void ShowFailMessage(){
		Debug.Log("fail!");
		PopUpManager.instance.ChangeOverlayText("Error !");
		PopUpManager.instance.OverlaySwitch(false);
		this.gameObject.SetActive(false);
	}
}
