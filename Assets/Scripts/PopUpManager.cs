using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour {
	public GameObject[] PopUpList;
	private static PopUpManager _instance = null;
	public static PopUpManager instance{
		get{
			if(!_instance){
				_instance = FindObjectOfType(typeof(PopUpManager)) as PopUpManager;
				if(!_instance){
					GameObject container = new GameObject();
					container.name = "FontGeneratorContainer";
					_instance = container.AddComponent(typeof(PopUpManager)) as PopUpManager;
				}
			}
			return _instance;
		}
	}

	void Update(){
		if (Input.GetButtonDown ("Pause")) {
			if(!PopUpList[0].GetComponentInChildren<PauseMenu>().paused){
				Time.timeScale = 0;
				PopUpList[0].SetActive(true);
				PopUpList[0].GetComponentInChildren<PauseMenu>().Pause();
			}
			else{
				PopUpList[0].GetComponentInChildren<PauseMenu>().Resume();
			}
		}
	}

	public void ShowResultPopUp(){
		PopUpList[1].GetComponentInChildren<ResultPopUp>().ShowScoreInfo();
		Time.timeScale = 0;
		PopUpList[1].SetActive(true);
	}

	
}
