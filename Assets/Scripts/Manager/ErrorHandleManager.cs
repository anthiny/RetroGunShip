using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorHandleManager : MonoBehaviour {
	public GameObject errorPopUp;
	private static ErrorHandleManager _instance = null;
	public static ErrorHandleManager instance{
		get{
			if(!_instance){
				_instance = FindObjectOfType<ErrorHandleManager>() as ErrorHandleManager;
				if(!_instance){
					GameObject container = new GameObject();
					container.name = "ErrorHandleManagerContainer";
					_instance = container.AddComponent(typeof(ErrorHandleManager)) as ErrorHandleManager;
				}
			}
			return _instance;
		}
	}

	public void CreateErrorPopUp(string errorType){
		GameObject errorPopUpParent = GameObject.Find("Ui");
		GameObject errorPopUpClone = Instantiate(errorPopUp);
		errorPopUpClone.GetComponent<ErrorPopUpContoller>().SettingPopUp(errorType);
		errorPopUpClone.transform.SetParent(errorPopUpParent.transform, false);
	}

}
