﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
			if(!PopUpList[0].GetComponentInChildren<PausePopUpController>().paused){
				Time.timeScale = 0;
				PopUpList[0].SetActive(true);
				PopUpList[0].GetComponentInChildren<PausePopUpController>().Pause();
			}
			else{
				PopUpList[0].GetComponentInChildren<PausePopUpController>().Resume();
			}
		}
	}

	public void ShowResultPopUp(){
		SoundManager.instance.mainSwitch("inGameBackGround",false);
		PopUpList[1].GetComponentInChildren<ResultPopUpController>().ShowScoreInfo();
		Time.timeScale = 0;
		PopUpList[1].SetActive(true);
	}
	
	public void ShowInputNickNamePopUp(){
		PopUpList[2].SetActive(true);
	}

	public void OverlaySwitch(bool value){
		PopUpList[3].SetActive(value);
	}

	public void ChangeOverlayText(string text){
		PopUpList[3].transform.GetChild(0).gameObject.GetComponent<Text>().text = text;
	}
}
