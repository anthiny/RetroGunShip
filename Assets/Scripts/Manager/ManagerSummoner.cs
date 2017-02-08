using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSummoner : MonoBehaviour {
	public GameObject managerPrefab;
	private GameObject managerObject;
	// Use this for initialization
	void Awake () {
		managerObject = GameObject.Find("Managers");
		if(managerObject == null){
			GameObject.Instantiate(managerPrefab).name = "Managers";
		}
	}
	
}
