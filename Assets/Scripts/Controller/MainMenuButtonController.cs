using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MonoBehaviour {

	public void StartButton(){
		SoundManager.instance.mainSwitch("mainMenu", false);
		SceneManager.LoadScene("Scene/InGame");
	}

	public void ExitButton(){
		Application.Quit();
	}
}