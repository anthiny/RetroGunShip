using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorPopUpContoller : MonoBehaviour {
	public Text title;
	public void SettingPopUp(string title){
		this.title.text = title;
	}
	public void CloseButton(){
		Destroy(this.gameObject);
	}
}
